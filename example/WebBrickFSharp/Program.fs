module WebBrick
open System
open System.IO
open System.Net
open System.Net.Mime
open System.Text

let prefix = "http://*:8088/"
if HttpListener.IsSupported = false then 
    Console.WriteLine("Not Supported!")
    exit(0)

Console.WriteLine("WebBrick start")
let hl = new HttpListener()
hl.Prefixes.Add( prefix )
hl.Start()

let bot = new Sample.simplebot_simple()
Console.WriteLine("simplebot_simple init")
bot.init()

while true do
    let context = hl.GetContext()
    let req = context.Request
    let res = context.Response

    res.StatusCode <- int HttpStatusCode.OK
    res.ContentType <- MediaTypeNames.Text.Html
    res.ContentEncoding <- Encoding.UTF8

    match req.Url.LocalPath with
        | "/fwd" -> bot.fwd()
        | "/back" -> bot.back()
        | "/left" -> bot.left()
        | "/right" -> bot.right()
        | "/stop" -> bot.stop()
        | _ -> ()
    
    System.Console.WriteLine(String.Format("req: {0}", req.Url))

    let sw = new StreamWriter( res.OutputStream )
    sw.WriteLine(String.Format("req: {0}", req.Url))
    sw.WriteLine("this is server program's response. ")
    sw.Flush()
    res.Close()
