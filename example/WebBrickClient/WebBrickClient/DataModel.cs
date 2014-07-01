using System;

namespace WebBrickClient
{
    public class ModelOption
    {
        public string Server { get; set; }
        public int Port { get; set; }
        public string URL { get; set; }

        public ModelOption()
        {
            this.Server = "172.16.0.4"; // "raspberrypi";
            this.Port = 8088;
            this.URL = "";
        }
        public ModelOption Clone()
        {
            var dest = new ModelOption
            {
                Server = this.Server,
                Port = this.Port,
                URL = this.URL
            };
            return dest;
        }
        public Uri Uri
        {
            get
            {
                return new Uri(string.Format("http://{0}:{1}/{2}", Server, Port, URL));
            }
        }
    }
    public class ModelMain
    {
        public ModelOption option { get; set; }
        public Uri Uri { get { return option.Uri; } }
        public ModelMain()
        {
            this.option = new ModelOption();
        }
    }

    public class ViewModelOption : BindableBase
    {
        protected ModelOption _model;
        public ViewModelOption(ModelOption model) { _model = model; }
        public ModelOption Model { get { return _model; } }


        public string Server
        {
            get { return _model.Server; }
            set
            {
                if (_model.Server != value)
                {
                    _model.Server = value;
                    this.OnPropertyChanged("Server");
                }
            }
        }
        public string Port
        {
            get { return _model.Port.ToString(); }
            set
            {
                if (_model.Port.ToString() != value)
                {
                    int port = 0;
                    if (int.TryParse(value, out port) == true)
                    {
                        _model.Port = port;
                        this.OnPropertyChanged("Port");
                    }
                }
            }
        }
        public string URL
        {
            get { return _model.URL; }
            set
            {
                if (_model.URL != value)
                {
                    _model.URL = value;
                    this.OnPropertyChanged("URL");
                }
            }
        }
    }
    public class ViewModelMain
    {
        protected ModelMain _model;
        public ViewModelMain(ModelMain model) { _model = model; }
    }
}

