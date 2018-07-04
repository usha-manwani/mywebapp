using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.IO.Pipes;

namespace trythis
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
         {
            var pipe = new NamedPipeServerStream("ffpipe", PipeDirection.InOut, 1, PipeTransmissionMode.Byte, PipeOptions.Asynchronous);
            var input = "rtsp://admin:admin123@192.168.1.96:554/";
            var inputFormat = "H264";
            var outputFormat = "webm";
            var output = pipe;
           
         

        }
    }
}