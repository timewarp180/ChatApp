using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Application = Xamarin.Forms.Application;
using TabbedPage = Xamarin.Forms.TabbedPage;

namespace ChatApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    
    public partial class TabbedPage1 : TabbedPage
    {
        public TabbedPage1()
        {
            InitializeComponent();
            On<Android>().SetToolbarPlacement(Xamarin.Forms.PlatformConfiguration.AndroidSpecific.ToolbarPlacement.Bottom);
            if (Application.Current.Properties.ContainsKey("email"))
            {
                email.Text = Application.Current.Properties["email"].ToString();
                name.Text = Application.Current.Properties["username"].ToString();
            }
        }

        private void LogoutButton_Clicked(object sender, EventArgs e)
        {
            Application.Current.Properties.Remove("email");
            Application.Current.Properties.Remove("name");
            Application.Current.SavePropertiesAsync();

            Application.Current.MainPage = new MainPage();
        }
    }
}