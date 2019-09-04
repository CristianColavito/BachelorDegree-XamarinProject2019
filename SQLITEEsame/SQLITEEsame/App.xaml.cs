using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace SQLITEEsame
{
    public partial class App : Application
    {
     private static SchedaController dbcontroller;
        
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage( new View.ItemListView());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
        public static SchedaController Dbcontroller
        {
            get
            {
                if (dbcontroller == null)
                {
                    dbcontroller = new SchedaController();
                }
                return dbcontroller;
            }
        }
    }
}
