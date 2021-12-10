using System;
using MobileAppDevFinalProject.Data;
using Xamarin.Forms;



using Xamarin.Forms.Xaml;

namespace MobileAppDevFinalProject
{
    public partial class App : Xamarin.Forms.Application
    {
        public static ActivitiesManager ActivitiesManager { get; set; }
        public App()
        {
//[x] Fun or useful 10 %
//[x] At least 3 Activities / Pages 10 % x
//[x]   A working list 10 %
//[x] A menu for navigation10 %
//[x]  A local Database or Use an API(Marvel, Google Maps, etc...) 30 %
//[x]  Include something that was not covered in class (Push Notifications, Web Browser, Accelerometer, etc...) 30%
            
            InitializeComponent();
            ActivitiesManager = new ActivitiesManager(new RestService());
            MainPage = new NavigationPage (new MainPage());
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
