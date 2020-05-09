using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

namespace ChatApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]

    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        ///private void logpass_ChildAdded(Object sender, System.EventArgs e)
       /// {
         ///   var button = new Button { BackgroundColor = Color.White, Text = "Show", TextColor = Color.Black };
         ///   OnParentSet(logpass);
          ///  logpass.ChildAdded += button;

       /// }

        private void Pass_Clicked(Object sender, EventArgs e)
        {
            if(string.Compare(pass.Text,"Hide") == 0)
            {
                pass.Text = "Show";
                logpass.IsPassword = true;
            }
            else
            {
                pass.Text = "Hide";
                logpass.IsPassword = false;
            }
        }
        private void Handle_CLicked(Object sender, EventArgs e)
        {
            var create = new create();
            Application.Current.MainPage = new NavigationPage(create);
            NavigationPage.SetHasNavigationBar(create, false);
        }

        private async void Signin_CLicked(Object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(logemail.Text) && !string.IsNullOrEmpty(logpass.Text))
            {
                if(Application.Current.Properties.ContainsKey("email") && Application.Current.Properties.ContainsKey("password") && string.Compare(Application.Current.Properties["email"].ToString(),logemail.Text) == 0 && string.Compare(Application.Current.Properties["password"].ToString(), logpass.Text) == 0)
                {
                    await DisplayAlert("Successful", "Sign in success.", "Okay");
                    var tab = new TabbedPage1();
                    Application.Current.MainPage = new NavigationPage(tab);
                    NavigationPage.SetHasNavigationBar(tab, false);
                }
                else
                {
                    await DisplayAlert("Invalid Data", "Invalid email address or password.", "Okay");
                }
                
                
            }
            else
            {
                await DisplayAlert("Missing Fields", "There are missing fields.", "Okay");
            }

        }

        private async void Signin2_CLicked(Object sender, EventArgs e)
        {
            if (Application.Current.Properties.ContainsKey("fb"))
            {
                await DisplayAlert("Successful", "Sign in success.", "Okay");
                var tab = new TabbedPage1();
                Application.Current.MainPage = new NavigationPage(tab);
                NavigationPage.SetHasNavigationBar(tab, false); 
            }
            else
            {
                await DisplayAlert("Invalid User", "Facebook user is not signed up.", "Okay");
            }

        }

        private async void Google_CLicked(Object sender, EventArgs e)
        {
            if (Application.Current.Properties.ContainsKey("google"))
            {
                await DisplayAlert("Successful", "Sign in success.", "Okay");
                var tab = new TabbedPage1();
                Application.Current.MainPage = new NavigationPage(tab);
                NavigationPage.SetHasNavigationBar(tab, false);
            }
            else
            {
                await DisplayAlert("Invalid User", "Google user is not signed up.", "Okay");
            }

        }

        private void logpass_ChildAdded(object sender, ElementEventArgs e)
        {

        }
    }
}