<%@ Page Language="C#"  CodeFile="Default.aspx.cs" Inherits="_Default" Debug="true"  %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
 <html>
 <head><title></title> 
 <script type="text/javascript" >

 var xmlhttp = null;
 var TimeOutId;
     
function AjaxGet(url,helm)
{ 
  if (xmlhttp == null)
  {  if (window.XMLHttpRequest) // code for IE7+, Firefox, Chrome, Opera, Safari
       xmlhttp = new XMLHttpRequest();
    else  // code for IE6, IE5
       xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");  
  }
  
 xmlhttp.onreadystatechange = function()
 {   if (xmlhttp.readyState==4)
     {  if ( (xmlhttp.status==200) ||  (xmlhttp.status==304) )
          { document.getElementById(helm).innerHTML = xmlhttp.responseText; }
          else { document.getElementById(helm).innerHTML = xmlhttp.status + " " +xmlhttp.statusText; }
    }
 }
 
   xmlhttp.open("GET",url,true);
   xmlhttp.send();
}
 
     var uniqueId = '<%= Guid.NewGuid().ToString() %>';

      function startTask()
      {  url = document.getElementById("URL").value;
            
         AjaxGet("default.aspx?startTask=" + uniqueId +"&url=" + url, "myDiv")
         document.getElementById('statusBorder').style.display = "block";
                
         document.getElementById('startBtn').innerHTML = "Cancel Task";

         document.getElementById('startBtn').onclick = cancelTask;

        TimeOutId = window.setTimeout("getStatus()", 1000);
                
         event.preventDefault;
     }


     function cancelTask() 
     {   AjaxGet("default.aspx?cancelTask=" + uniqueId, "myDiv")
        // document.getElementById('statusBorder').style.display = "block";
         window.clearTimeout(TimeOutId);

         event.preventDefault;
     } 


     function getStatus() 
     {   var url = 'default.aspx?getStatus=' + uniqueId;
         AjaxGet(url, "status");

         var data = document.getElementById('status').innerHTML;
        //   alert(" " + data);

         if (data.length > 4) return;  // data is error message, no timeout is set

         data = data.substr(0, data.length - 1); // remove %
  
         if (data != "100")
          {  document.getElementById('statusFill').style.width =  data * 4 +"px";
             TimeOutId= window.setTimeout("getStatus()", 1000);
          }
          else
          {  document.getElementById("myDiv").innerHTML = "Done";
             document.getElementById('statusBorder').style.display = "none";  
             alert("The task has finished");
          } 
  }
    
</script> 
     
<style> 
/* ProgressBar */
#statusBorder
{  position:relative; height:15px; width:400px;
   border:solid 1px gray; display:none;
}
#statusFill
{   top:0; left:0; width:0;
   background-color:Blue; height:15px;
}
</style>
</head>
 <body>

<div style="padding:6px;"><b style="font-size:smaller" >Download URL</b><input id="URL" style="width:400px;font-size:9pt;margin-left:8px;padding:2px;border:1px solid balck;border-style:groove" type="text"   value="http://www.codeproject.com/KB/aspnet/492789/AsyncWebRequest-Events.zip"  />
<p><a href="#" id="startBtn"  onclick="startTask()" >Start Long Running Task <%=DummyTaskString %></a> </p>
</div>
<div id="statusBorder" ><div id="statusFill"></div></div>
<div id="myDiv"></div>
<div id="status" ></div>
</body>
</html>   


          