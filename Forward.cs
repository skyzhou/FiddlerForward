using System;
using System.Collections.Generic;
using System.Text;
using Fiddler;
using System.Windows.Forms;
using System.Collections;
using FiddlerForward;
using System.IO;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Runtime.Serialization.Formatters.Binary;
using System.Drawing.Imaging;

public class Forward : IAutoTamper,IFiddlerExtension
{
    //创建插件的选项卡页
    private TabPage tabPage;

    //MyControl自定义控件
    private ForwardContro forwardCtrl;


    private string combo;

    public Forward()
    {
        //构造函数中实例化对象
        this.tabPage = new TabPage("Forward");
        
        //选项卡的名字为combo
        this.forwardCtrl = new ForwardContro();

        this.combo = this.forwardCtrl.combo;
    }

    public void OnLoad()
    {
        //将用户控件添加到选项卡中
        this.tabPage.Controls.Add(this.forwardCtrl);

        //为选项卡添加icon图标，这里使用Fiddler 自带的
        this.tabPage.ImageIndex = (int)Fiddler.SessionIcons.Redirect;

        //将tabTage选项卡添加到Fidder UI的Tab 页集合中
        FiddlerApplication.UI.tabsViews.TabPages.Add(this.tabPage);

        this.forwardCtrl.setDataView();
        this.tabPage.Resize += this.resizeWin;
        
        this.forwardCtrl.resizeWin(this.tabPage.Width, this.tabPage.Height);

        //注册热键
        //ForwardContro.RegisterHotKey(this.tabPage.Handle, 100, ForwardContro.KeyModifiers.Shift, Keys.S);
    }
    private void resizeWin(object sender, EventArgs e)
    {
        this.forwardCtrl.resizeWin(this.tabPage.Width,this.tabPage.Height);
    }
    public void OnBeforeUnload()
    {
        this.forwardCtrl.rulesToFile();
        this.forwardCtrl.settingToFile();
    }
    private Boolean isTxtFile(string url) {
        Regex rImg = new Regex("txt|htm|html|css|js", RegexOptions.IgnoreCase);
        string extname = Path.GetExtension(url);

        if (rImg.IsMatch(extname))
        {
            return true;
        }
        return false;
    }
    private Boolean isImageFile(string url) {
        Regex rTxt = new Regex("jpg|jpeg|png|gif|ico", RegexOptions.IgnoreCase);
        string extname = Path.GetExtension(url);

        if (rTxt.IsMatch(extname))
        {
            return true;
        }
        return false;
    }
    private Boolean isJsFile(string url) { 
        Regex rJs = new Regex("js", RegexOptions.IgnoreCase);
        string extname = Path.GetExtension(url);

        if (rJs.IsMatch(extname))
        {
            return true;
        }
        return false;
    }
    private ArrayList readUrl(string url)
    {
        System.Net.HttpWebRequest request = null;
        System.Net.HttpWebResponse response = null;

        ArrayList res = new ArrayList();

        try
        {
            request = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(url);
            request.Method = "get";
            request.Headers.Add("from-fiddler","true");
            response = (System.Net.HttpWebResponse)request.GetResponse();
            System.Text.Encoding encode = null;

            try
            {
                encode = System.Text.Encoding.GetEncoding(response.CharacterSet);
            }
            catch
            {
                encode = System.Text.Encoding.UTF8;
            }

            System.IO.Stream stream = response.GetResponseStream();

            System.IO.StreamReader read = new System.IO.StreamReader(stream, encode);
            string txt = read.ReadToEnd();
            res.Add(txt);

            response.Close();
        }
        catch
        {
            res.Clear();
        }
        return res;
    }
    private ArrayList fitlerUrls(ArrayList list) {
        ArrayList rules = this.forwardCtrl.rules;
        ArrayList fileList = new ArrayList();
        foreach (string[] u in list)
        {
            string uri = u[0];
            string hit = "no";
            foreach (string[] row in rules)
            {
                string enable = row[0];
                string match = row[1];
                string action = row[2];
                if (!String.IsNullOrEmpty(match.Trim()) && enable == "1")
                {
                    if (uri.IndexOf(match) > -1) {
                        uri = uri.Split('?')[0];
                        uri = uri.Replace(match, action.Trim());
                        hit = "yes";
                        break;
                    }
                        
                }

            }
            if (!string.IsNullOrEmpty(uri.Trim())) {
                //替换后的url 原url 请求方式  是否命中规则
                fileList.Add(new string[] { uri ,u[0],u[1],hit});
            }
        }

        return fileList;
    }
    //创建 a替换b的规则，生效
    //如果是单请求，匹配，用b，不匹配，用远程
    //如果是combo请求，根据单文件路径，如果匹配，单个文件用本地，如果不匹配，单个文件用远程，集合返回
    // Called before the user can edit a request using the Fiddler Inspectors
    public void AutoTamperRequestBefore(Session oSession){

        ArrayList rules = this.forwardCtrl.rules;
        ArrayList oFileList = new ArrayList();
        ArrayList nFileList = new ArrayList();
        ArrayList aDataList = new ArrayList();
        string fromFiddler = oSession["Request", "from-fiddler"];
        Boolean enable = false;

        if (!string.IsNullOrEmpty(fromFiddler.Trim()))
        {
            return;
        }

        if (rules.Count < 1) {
            return;
        }

        foreach (string[] row in rules)
        {
            if (row[0] == "1") {
                enable = true;
                break;
            }
        }

        if (!enable) {
            return;
        }

        string abUrl = oSession.fullUrl.Split('?')[0];
        if (oSession.uriContains(this.combo)) {
            
            string[] parts = abUrl.Split(new string[] { this.combo }, StringSplitOptions.None);
            string[] paths = parts[1].Split(',');
            for (int i = 0; i < paths.Length; i++)
            {
                string url = parts[0] + paths[i];
                string uri = url;
                oFileList.Add(new string[] { uri, "combo" });
            } 
        }
        else{
            oFileList.Add(new string[] { oSession.fullUrl, "single" });
        }

        nFileList = this.fitlerUrls(oFileList);

        foreach (string[] u in nFileList)
        {
            string nUri = u[0];
            string oUri = u[1];
            string mode = u[2];
            string hit = u[3];

            Uri uriAddress = new Uri(nUri);

            ArrayList fileData = new ArrayList();
             

            //如果是本地路径规则
            //如果本地不存在，则拉取远程
            if (uriAddress.IsFile)
            {
                if (File.Exists(nUri))
                {
                    if (this.isTxtFile(nUri))
                    {
                        string txt = File.ReadAllText(nUri);
                        fileData.Add(txt);
                    }
                    else {
                        fileData.Add(uriAddress);
                    }
                    
                }
                else if (this.isTxtFile(nUri))
                {
                    
                    fileData = this.readUrl(oUri);
                    
                    if (this.forwardCtrl.setting["DownLoadSync"] == "yes")
                    {
                        string data = (string)fileData[0];
                        if (!string.IsNullOrEmpty(data)) {
                            string path = Path.GetDirectoryName(nUri);

                            if (!Directory.Exists(path))
                            {
                                Directory.CreateDirectory(path);
                            }
                            File.WriteAllText(nUri, data);
                        }
                    } 
                    
                }
                
            }
            
            //如果是远程的，且是combo请求，则跳过
            else if (mode == "combo")
            {
                fileData = this.readUrl(nUri);
            }
            //如果是远程转发规则
            else if(hit == "yes")
            {
                oSession.url = uriAddress.Host + uriAddress.AbsolutePath;
            }
            //将单个文件获取到的内容加入总文件内容集合
            //如果这个文件没匹配到本地规则，且不是combo请求，则空
            aDataList.Add(fileData);
        }

        //遍历判断是否命中
        string txtData = "";
        Uri byteUri = null;
        
        foreach (ArrayList data in aDataList)
        {
            
            if (data.Count > 0) {
                if (data[0] is Uri) {
                    byteUri = (Uri)data[0];
                }
                else if (data[0] is string) {
                    txtData += (string)data[0];
                }
            }
            
        }

        //如果获取到文本内容或有本地uri 则拦截
        if (txtData.Trim() != "" || byteUri != null)
        {
            oSession.utilCreateResponseAndBypassServer();
            oSession.responseCode = 200;

            if (txtData.Trim() != "")
            {
                oSession.utilSetResponseBody(txtData);
            }
            else {
                oSession.LoadResponseFromFile(byteUri.OriginalString);
            }

        } 
        
    }

    // Called after the user has had the chance to edit the request using the Fiddler Inspectors, but before the request is sent
    public void AutoTamperRequestAfter(Session oSession){
    }

    // Called before the user can edit a response using the Fiddler Inspectors, unless streaming.
    public void AutoTamperResponseBefore(Session oSession){
        
    }

    // Called after the user edited a response using the Fiddler Inspectors.  Not called when streaming.
    public void AutoTamperResponseAfter(Session oSession){
    
    }

    // Called Fiddler returns a self-generated HTTP error (for instance DNS lookup failed, etc)
    public void OnBeforeReturningError(Session oSession){
    
    }
}
