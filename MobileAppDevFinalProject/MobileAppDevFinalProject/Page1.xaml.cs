using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileAppDevFinalProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
            menuBtnMain.BackgroundColor = Color.Default;
            menuBtnMain.TextColor = Color.DarkOliveGreen;
            menuBtnP2.BackgroundColor = Color.Default;
            menuBtnP2.TextColor = Color.DarkOliveGreen;
            menuBtnP1.BackgroundColor = Color.DarkOliveGreen;
            menuBtnP1.TextColor = Color.White;
        }
        async void mBtnClick(object sender, EventArgs args)
        {
            //await DisplayAlert("Clicked!", "reee", "REEE");
            await Navigation.PushAsync(new MainPage());
        }
        //async void p1BtnClick(object sender, EventArgs args)
        //{
        //    //await DisplayAlert("Clicked!","reee","REEE");
        //    await Navigation.PushAsync(new Page1());
        //}
        async void p2BtnClick(object sender, EventArgs args)
        {
            //await DisplayAlert("Clicked!", "reee", "REEE");
            await Navigation.PushAsync(new Page2());
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.ActivitiesManager.GetTasksAsync(pb);
        }
        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            NotBoringActivity nb = (NotBoringActivity)e.SelectedItem;
            
            //make modal???
            await DisplayAlert("Worthless Info", nb.Activity, "OK");
                //activity
                //type
                //participants
                //price
                //link
                //key

        }
    }
}