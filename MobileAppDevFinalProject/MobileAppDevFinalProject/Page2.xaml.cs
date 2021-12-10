using System;
using Urho;
using MobileAppDevFinalProject.Models;
using Urho.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace MobileAppDevFinalProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : ContentPage
    {
        UrhoSurface urhoSurface;
        Charts urhoApp;
        Slider selectedBarSlider;
        SensorSpeed speed = SensorSpeed.UI;
        public Page2()
        {
            InitializeComponent();
            var restartBtn = new Button { Text = "Restart" };
            restartBtn.Clicked += (sender, e) => StartUrhoApp();

            urhoSurface = new UrhoSurface();
            urhoSurface.VerticalOptions = LayoutOptions.FillAndExpand;

            Slider rotationSlider = new Slider(0, 500, 250);
            //rotationSlider.ValueChanged += (s, e) => Console.WriteLine($"slider val:{e.NewValue - e.OldValue}");
            //rotationSlider.ValueChanged += (s, e) => urhoApp?.Rotate((float)(e.NewValue - e.OldValue));

            selectedBarSlider = new Slider(0, 5, 2.5);
            selectedBarSlider.ValueChanged += OnValuesSliderValueChanged;

            Title = "weeee \\o/ eeeeeeee";
            Content = new StackLayout
            {
                Padding = new Thickness(12, 12, 12, 40),
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children = {
                    urhoSurface,
                    restartBtn,
                    new Label { Text = "ROTATION::" },
                    rotationSlider,
                    new Label { Text = "SELECTED VALUE:" },
                    selectedBarSlider,
                }
            };
            Accelerometer.ReadingChanged += Accelerometer_ReadingChanged;
            ToggleAccelerometer();


        }
        void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs e)
        {
            var data = e.Reading;
            urhoApp?.Rotate((float)(data.Acceleration.X * 1.2));
            //for whatever reason, the emulated device I had setup does not read Y acceleration
            //urhoApp?.RotateY((float)(data.Acceleration.Y));
            urhoApp?.RotateZ((float)(data.Acceleration.Z * 1.1));

            //urhoApp?.RotateThemAll(((float)data.Acceleration.X * 2), ((float)data.Acceleration.Y * 2), ((float)data.Acceleration.Z * 2));

            //Console.WriteLine($"Reading: X: {data.Acceleration.X}, Y: {data.Acceleration.Y}, Z: {data.Acceleration.Z}");
            // Process Acceleration X, Y, and Z
        }
        public void ToggleAccelerometer()
        {
            try
            {
                if (Accelerometer.IsMonitoring)
                    Accelerometer.Stop();
                else
                    Accelerometer.Start(speed);
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Feature not supported on device
            }
            catch (Exception ex)
            {
                // Other error has occurred.
            }
        }

        protected override void OnDisappearing()
        {
            UrhoSurface.OnDestroy();
            base.OnDisappearing();
            ToggleAccelerometer();
        }

        void OnValuesSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (urhoApp?.SelectedBar != null)
                urhoApp.SelectedBar.Value = (float)e.NewValue;
        }

        private void OnBarSelection(Urho.Bar bar)
        {
            //reset value
            selectedBarSlider.ValueChanged -= OnValuesSliderValueChanged;
            selectedBarSlider.Value = bar.Value;
            selectedBarSlider.ValueChanged += OnValuesSliderValueChanged;
        }

        protected override async void OnAppearing()
        {
            StartUrhoApp();
        }

        async void StartUrhoApp()
        {
            urhoApp = await urhoSurface.Show<Charts>(new ApplicationOptions(assetsFolder: null) { Orientation = ApplicationOptions.OrientationType.LandscapeAndPortrait });
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
        //async void p2BtnClick(object sender, EventArgs args)
        //{
        //    //await DisplayAlert("Clicked!", "reee", "REEE");
        //    await Navigation.PushAsync(new Page2());
        //}

    }
}