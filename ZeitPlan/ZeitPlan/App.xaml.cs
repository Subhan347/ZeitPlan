using Firebase.Database;
using Firebase.Storage;
using SQLite;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZeitPlan.LoginSystem;
using ZeitPlan.Services;
using ZeitPlan.Views;

namespace ZeitPlan
{
    public partial class App : Application
    {
        public static string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "dbZeitplan.db3");
        public static SQLiteConnection db = new SQLiteConnection(dbPath);

        //Firebase Connections  ======================================
        public static FirebaseStorage FirebaseStorage = new FirebaseStorage("gs://zeitplan-153be.appspot.com");

        public static FirebaseClient firebaseDatabase = new FirebaseClient("https://zeitplan-153be-default-rtdb.firebaseio.com/");

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new NavigationPage(new HomePage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
