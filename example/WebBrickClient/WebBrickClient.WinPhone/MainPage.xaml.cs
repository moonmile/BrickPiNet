using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using WebBrickClient.WinPhone.Resources;
using Xamarin.Forms;

namespace WebBrickClient.WinPhone
{
    public partial class MainPage : PhoneApplicationPage
    {
        // コンストラクター
        public MainPage()
        {
            InitializeComponent();

            Forms.Init();
            Content = WebBrickClient.App.GetMainPage().ConvertPageToUIElement(this);
        }
    }
}