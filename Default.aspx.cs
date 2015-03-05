using System;
using System.Web;
using System.Threading;
using System.Net;
using System.IO;

 
public delegate void ProgressCallback(object sender, int Progress);
 
public partial class _Default : System.Web.UI.Page
{
    Boolean useDummyTask = false; // Set this as you desire
    public string DummyTaskString = ""; 

    protected void Page_Load(object sender, EventArgs e)
    {   // Instruct browser not to cache the results
        Response.AddHeader("cache-control", "no-cache");
        
        if (useDummyTask) DummyTaskString = "(uses a dummy task)";

        string TaskID;

        // Handle one of three verbs: startTask, cancelTask, getStatus
        if (Request["startTask"] != null)
        {
            TaskID = Request["startTask"];

            AsyncWebRequest req = new AsyncWebRequest(); 

            req.useDummyTask = useDummyTask;

            string page_path = Server.MapPath("");
            string downloadURL = Request["url"];
            int i = downloadURL.LastIndexOf('/');
            string fileName = downloadURL.Substring(i + 1);

            req.localfile = page_path + "\\" + fileName;

            req.url = downloadURL;

            req.ProgressChanged += new ProgressCallback(bw_ProgressChanged);
            req.TaskID = TaskID;

            HttpRuntime.Cache["DownloadRquest_" + TaskID] = req;

            req.ExecuteRequest();

            Response.Write("Task started");
            Response.End();
            return;
        }


        if (Request["cancelTask"] != null)
        {
            TaskID = Request["cancelTask"];

            AsyncWebRequest req = (AsyncWebRequest)HttpRuntime.Cache["DownloadRquest_" + TaskID];
            req.Cancel = true;

            while (req.CompletionStatus != "Canceled")
            { Thread.Sleep(100); }

            HttpRuntime.Cache.Remove("DownloadRquest_" + TaskID);

            Response.Write("Task canceled");
            Response.End();
            return;
        }

        if (Request["getStatus"] != null)
        {
            TaskID = Request["getStatus"];
            string st = (string)HttpRuntime.Cache["Task_state_" + TaskID];

            if (st.Length > 3) HttpRuntime.Cache.Remove("DownloadRquest_" + TaskID);

            Response.Write(st);
            Response.End();
            return;
        }
    }
      
    void bw_ProgressChanged(object sender, int Progress)
    {   string TaskID = ((AsyncWebRequest)sender).TaskID;
        if (Progress != -1)
            HttpRuntime.Cache["Task_state_" + TaskID] = Progress.ToString() + "%";
        else
            HttpRuntime.Cache["Task_state_" + TaskID] = ((AsyncWebRequest)sender).CompletionStatus;
    }
      
}


public class AsyncWebRequest 
{ 
    public string url, localfile;

    public string TaskID;

    public event ProgressCallback ProgressChanged;

    public Boolean Cancel = false;
    public Boolean useDummyTask = false;

    public string CompletionStatus;
      
    delegate void MethodInvoker();
     
    public void ExecuteRequest()
    {   MethodInvoker simpleDelegate;
        
        if (useDummyTask) simpleDelegate = new MethodInvoker(this.RunDummyTask);
        else simpleDelegate= new MethodInvoker(this.RunTask);

        simpleDelegate.BeginInvoke(null,null);
    }
     

    private void RunDummyTask()
    {
        for (int i = 1; i <= 100; i++)
        {
            if (Cancel)
            { CompletionStatus = "Canceled"; break; }
            // Update progress
            ProgressChanged(this, i);
            Thread.Sleep(200);
        }
    }      

    private void RunTask()
    {    
        WebRequest req = WebRequest.Create(url);
        WebResponse resp;

        try { resp = req.GetResponse(); }
        catch (WebException e)
        {   CompletionStatus = e.Message;
            ProgressChanged(this,-1);
            return;
        }
         
        long TotalBytes =  resp.ContentLength;
        int BlockSize = 32768;

        Stream RecvStream = resp.GetResponseStream();
        //  RecvStream.ReadTimeout = 3000;
        // RecvStream.WriteTimeout = 3000;

        Byte[] Buffer = new Byte[BlockSize];

        using (FileStream fs = new FileStream(localfile, FileMode.Create))
        { 
            long ByteCount = 0;
          
            while (true)
            { 
                if (Cancel)
                {  CompletionStatus = "Canceled"; break; }

                // Read incoming data
                int BytesRead = RecvStream.Read(Buffer, 0, BlockSize);
                if (BytesRead == 0) break;
                ByteCount += BytesRead;
                fs.Write(Buffer, 0, BytesRead);
              
                // Update progress
                int Progress = (int)( (double)ByteCount / TotalBytes * 100);
                if (Progress <= 100) ProgressChanged(this, Progress);  
            }
        }
    } 
}
 