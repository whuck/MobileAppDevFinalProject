using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileAppDevFinalProject
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            menuBtnMain.BackgroundColor = Color.DarkOliveGreen;
            menuBtnMain.TextColor = Color.White;
            
            menuBtnP2.BackgroundColor = Color.Default;
            menuBtnP2.TextColor = Color.DarkOliveGreen;
            
            menuBtnP1.BackgroundColor = Color.Default;
            menuBtnP1.TextColor = Color.DarkOliveGreen;
        }
        async void mBtnClick(object sender, EventArgs args)
        {
            //await DisplayAlert("Clicked!", "reee", "REEE");
            await Navigation.PushAsync(new MainPage());
        }
        async void p1BtnClick(object sender, EventArgs args)
        {
            //await DisplayAlert("Clicked!","reee","REEE");
            await Navigation.PushAsync(new Page1());
        }
        async void p2BtnClick(object sender, EventArgs args)
        {
            //await DisplayAlert("Clicked!", "reee", "REEE");
            await Navigation.PushAsync(new Page2());
        }
    }
}
