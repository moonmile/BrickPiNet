namespace WebBrickClientFs
open Xamarin.Forms
open System.Net.Http

type App() = 
    
    static let _Model = new ModelMain()
    static member Model
        with get() = _Model
    static member GetMainPage() =
        new NavigationPage(new MainPage())

and MainPage() as this =
    inherit ContentPage() 

    let mutable _result:Label = null

    do 
        let label = new Label(Text="WebBrick Client Sampple")
        let fwd = new Button(Text="Forward")
        let back = new Button(Text="Back")
        let left = new Button(Text="Left")
        let right = new Button(Text="Right")
        let stop = new Button(Text="Stop")
        let option = new Button(Text="Option")
        let result = new Label(Text="result")
        this.Padding <- new Thickness(5.,20.,5.,5.)
        let layout = new StackLayout()
        layout.Children.Add( label )
        layout.Children.Add( fwd )
        layout.Children.Add( back )
        layout.Children.Add( left )
        layout.Children.Add( right )
        layout.Children.Add( stop )
        layout.Children.Add( option )
        layout.Children.Add( result )
        this.Content <- layout
        _result <- result

        fwd.Clicked.Add( fun _ -> 
            let hc = new HttpClient()
            let res = hc.GetStringAsync(App.Model.Uri.ToString() + "fwd").Result
            _result.Text <- res
            )
        back.Clicked.Add( fun _ -> 
            let hc = new HttpClient()
            let res = hc.GetStringAsync(App.Model.Uri.ToString() + "back").Result
            _result.Text <- res
            )
        left.Clicked.Add( fun _ -> 
            let hc = new HttpClient()
            let res = hc.GetStringAsync(App.Model.Uri.ToString() + "left").Result
            _result.Text <- res
            )
        right.Clicked.Add( fun _ -> 
            let hc = new HttpClient()
            let res = hc.GetStringAsync(App.Model.Uri.ToString() + "right").Result
            _result.Text <- res
            )
        stop.Clicked.Add( fun _ -> 
            let hc = new HttpClient()
            let res = hc.GetStringAsync(App.Model.Uri.ToString() + "stop").Result
            _result.Text <- res
            )

        option.Clicked.Add( fun _ -> 
            let data = App.Model.option.Clone()
            let vm = new ViewModelOption(data)
            let page = new OptionPage()
            page.BindingContext <- vm 
            this.Navigation.PushAsync(page) |> ignore
        )
        
and OptionPage() as this =
    inherit ContentPage() 

    do 
        this.Padding <- new Thickness(5.,20.,5.,5.)
        let layout = new StackLayout()
        layout.Children.Add( new Label(Text="Options"))
        layout.Children.Add( new Label(Text="Server"))
        layout.Children.Add( 
            let t = new Entry(Keyboard=Keyboard.Text, Placeholder="servername")
            t.SetBinding(Entry.TextProperty, "Server")
            t )
        layout.Children.Add( new Label(Text="Port"))
        layout.Children.Add( 
            let t = new Entry(Keyboard=Keyboard.Numeric, Placeholder="80")
            t.SetBinding(Entry.TextProperty, "Port")
            t )
        layout.Children.Add( new Label(Text="URL"))
        layout.Children.Add( 
            let t = new Entry(Keyboard=Keyboard.Text, Placeholder="/")
            t.SetBinding(Entry.TextProperty, "URL")
            t )
        layout.Children.Add( 
            let b = new Button(Text="Cancel")
            b.Clicked.Add( fun _ -> this.Navigation.PopAsync() |> ignore )
            b )
        layout.Children.Add( 
            let b = new Button(Text="Ok")
            b.Clicked.Add( fun _ -> 
                    App.Model.option <- (this.BindingContext :?> ViewModelOption).Model
                    this.Navigation.PopAsync() |> ignore   )
            b )

        this.Content <- layout

