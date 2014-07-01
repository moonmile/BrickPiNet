using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Http;

namespace WebBrickClient
{
    public partial class MainPage  
    {
        public MainPage()
        {
            InitializeComponent();
        }
        /// <summary>
        /// display option page
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        async void OnClickOption( object sender, EventArgs e ) 
        {
            var data = App.Model.option.Clone();
            var vm = new ViewModelOption(data);
            var page = new OptionPage();
            page.BindingContext = vm;
            await this.Navigation.PushAsync(page);
        }
        /// <summary>
        /// Raises the click forward event.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        async void OnClickForward( object sender, EventArgs e ) 
        {
            var hc = new HttpClient();
            var res = await hc.GetStringAsync(App.Model.Uri + "fwd");
            this.result.Text = res;
        }
        /// <summary>
        /// Raises the click back event.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        async void OnClickBack( object sender, EventArgs e ) 
        {
            var hc = new HttpClient();
            var res = await hc.GetStringAsync(App.Model.Uri + "back");
            this.result.Text = res;
        }
        /// <summary>
        /// Raises the click left event.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        async void OnClickLeft( object sender, EventArgs e ) 
        {
            var hc = new HttpClient();
            var res = await hc.GetStringAsync(App.Model.Uri + "left");
            this.result.Text = res;
        }
        /// <summary>
        /// Raises the click right event.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        async void OnClickRight( object sender, EventArgs e ) 
        {
            var hc = new HttpClient();
            var res = await hc.GetStringAsync(App.Model.Uri + "right");
            this.result.Text = res;
        }
        /// <summary>
        /// Raises the click stop event.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        async void OnClickStop( object sender, EventArgs e ) {
            var hc = new HttpClient();
            var res = await hc.GetStringAsync(App.Model.Uri + "stop");
            this.result.Text = res;
        }
    }
}
