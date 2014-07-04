namespace WebBrickClientFs
open System
open System.ComponentModel

type ModelOption() =
    member val Server = "172.16.0.4" with get, set
    member val Port = 8088 with get, set
    member val URL = "" with get, set

    member this.Clone() =
        new ModelOption( 
            Server = this.Server,
            Port = this.Port,
            URL = this.URL )
    member this.Uri
        with get() = 
            new Uri(String.Format("http://{0}:{1}/{2}", this.Server, this.Port, this.URL))

type ModelMain() =
    member val option:ModelOption = new ModelOption() with get, set
    member this.Uri 
        with get() = this.option.Uri 

type ViewModelBase() =
    let propertyChangedEvent = new DelegateEvent<PropertyChangedEventHandler>()
    interface INotifyPropertyChanged with
        [<CLIEvent>]
        member x.PropertyChanged = propertyChangedEvent.Publish
    member x.OnPropertyChanged propertyName = 
        propertyChangedEvent.Trigger([| x; new PropertyChangedEventArgs(propertyName) |])

type ViewModelOption(model:ModelOption) =
    inherit ViewModelBase()
    let mutable _model = model
    member this.Model 
        with get() = _model

    member this.Server 
        with get() = _model.Server
        and set(value) = 
            if _model.Server <> value then
                _model.Server <- value
                base.OnPropertyChanged("Server")
    member this.Port 
        with get() = _model.Port.ToString()
        and set(value) = 
            if _model.Port.ToString() <> value then
                _model.Port <- Int32.Parse( value )
                base.OnPropertyChanged("Port")
    member this.URL 
        with get() = _model.URL
        and set(value) = 
            if _model.URL <> value then
                _model.URL <- value
                base.OnPropertyChanged("URL")

type ValueModelMain(model:ModelMain) = 
    let mutable _model = model
