using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZeitPlan.LoginSystem;
using ZeitPlan.Models;

namespace ZeitPlan
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
       
        public HomePage()
        {
            InitializeComponent();
            try
            {
                DataList.ItemsSource = App.db.Table<Users>().ToList();
            }
            catch (Exception ex)
            {

                DisplayAlert("Error", "Something went wrong, please try again later.Error:" + ex.Message, "Ok");
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new Register());
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Login());
        }
    }
}