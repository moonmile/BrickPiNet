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

while true do
    let context = hl.GetContext()
    let req = context.Request
    let res = context.Response

    res.StatusCode <- int HttpStatusCode.OK
    res.ContentType <- MediaTypeNames.Text.Html
    res.ContentEncoding <- Encoding.UTF8

    let sw = new StreamWriter( res.OutputStream )
    sw.WriteLine(String.Format("req: {0}", req.Url))
    sw.WriteLine("this is server program's response. ")
    sw.Flush()
    res.Close()


