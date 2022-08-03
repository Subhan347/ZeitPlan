using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZeitPlan.Models;

namespace ZeitPlan.LoginSystem
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Register());
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtEmail.Text))
            {
                await DisplayAlert("Alert", "Please fill all required entries and try again.", "Ok");
                return;
            }
            try
            {
                ProgressInd.IsRunning = true;
                var check = (await App.firebaseDatabase.Child("Users").OnceAsync<Users>()).FirstOrDefault(x => x.Object.Email == txtEmail.Text && x.Object.Password == txtPassword.Text);
                if (check == null)
                {
                    ProgressInd.IsRunning = false;
                    await DisplayAlert("Alert", "This Email and Password is Incorrect.", "Ok");
                    return;
                }
                else
                {
                    await Navigation.PushAsync(new UsersList());
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Message", "Something Went wrong \n" + ex.Message, "OK");

            }

        }
    }
}