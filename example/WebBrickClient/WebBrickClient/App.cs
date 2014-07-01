using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace WebBrickClient
{
    public class App
    {
        public static Page GetMainPage()
        {
            return new NavigationPage(new MainPage());
        }
        protected static ModelMain _Model = new ModelMain();
        public static ModelMain Model { get { return _Model; } }
    }
}
