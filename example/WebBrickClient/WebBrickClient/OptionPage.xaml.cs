using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace WebBrickClient
{
    public partial class OptionPage 
    {
        public OptionPage()
        {
            InitializeComponent();
        }
        
        void OnCancel( object sender, EventArgs e )
        {
            this.Navigation.PopAsync();
        }
        void OnOk(object sender, EventArgs e)
        {
            App.Model.option = ((ViewModelOption)this.BindingContext).Model;
            this.Navigation.PopAsync();
        }
    }
}

