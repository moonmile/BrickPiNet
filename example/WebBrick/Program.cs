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

                switch (req.Url.LocalPath)
                {
                    case "/fwd": bot.fwd(); break;
                    case "/back": bot.back(); break;
                    case "/left": bot.left(); break;
                    case "/right": bot.right(); break;
                    case "/stop": bot.stop(); break;
                }
                Console.WriteLine(string.Format("req: {0}", req.Url));

                StreamWriter sw = new StreamWriter(res.OutputStream);
                sw.WriteLine(string.Format("req: {0}", req.Url));
                sw.WriteLine("this is server program's response. ");
                sw.Flush();
                res.Close();
            }
        }
    }
}
