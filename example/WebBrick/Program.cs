using System;
using System.IO;
using System.Net;
using System.Net.Mime;
using System.Text;

// gmcs /o:webbrick.exe /r:BrickPiNet.dll Program.cs

namespace WebBrick
{
    class Program
    {
        static void Main(string[] args)
        {
            string prefix = "http://*:8088/";

            if (!HttpListener.IsSupported)
            {
                Console.WriteLine("Not Supported!");
                return;
            }
            Console.WriteLine("start");
            HttpListener hl = new HttpListener();
            hl.Prefixes.Add(prefix);
            hl.Start();

            var bot = new Sample.simplebot_simple();
            Console.WriteLine("simplebot_simple init");
            bot.init();


            while (true)
            {
                HttpListenerContext context = hl.GetContext();
                HttpListenerRequest req = context.Request;
                HttpListenerResponse res = context.Response;

                res.StatusCode = (int)HttpStatusCode.OK;
                res.ContentType = MediaTypeNames.Text.Html;
                res.ContentEncoding = Encoding.UTF8;

                if (req.Url.ToString().IndexOf("/fwd") != -1) bot.fwd();
                if (req.Url.ToString().IndexOf("/back") != -1) bot.back();
                if (req.Url.ToString().IndexOf("/left") != -1) bot.left();
                if (req.Url.ToString().IndexOf("/right") != -1) bot.right();
                if (req.Url.ToString().IndexOf("/stop") != -1) bot.stop();

                StreamWriter sw = new StreamWriter(res.OutputStream);
                sw.WriteLine(string.Format("req: {0}", req.Url));
                sw.WriteLine("this is server program's response. ");
                sw.Flush();
                res.Close();
            }
        }
    }
}
