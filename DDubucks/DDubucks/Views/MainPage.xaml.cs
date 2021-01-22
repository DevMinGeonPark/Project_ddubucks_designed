using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DDubucks.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {

            InitializeComponent();

            List<dynamic> dynamics = new List<dynamic>();

            // 원본이미지 경로
            // http://www.123mobilewallpapers.com/wp-content/uploads/2016/02/sweet_valentines_day_coffee_heart.jpg
            dynamics.Add(new { ImageSrc = "banner_01.png" });

            // http://www.123mobilewallpapers.com/wp-content/uploads/2014/10/need_more_coffee.jpg
            dynamics.Add(new { ImageSrc = "banner_02.gif" });

            // http://www.123mobilewallpapers.com/wp-content/uploads/2015/02/valentine_couples_coffee.png
            dynamics.Add(new { ImageSrc = "banner_03.jpg" });

            this.mainView.ItemsSource = dynamics;

            // 3초 간격으로 자동 스크롤이 되도록 합니다.
            Device.StartTimer(TimeSpan.FromSeconds(3), (Func<bool>)(() =>
            {
                this.mainView.Position = (this.mainView.Position + 1) % 3;

                return true;
            }));
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MapPage());
        }
    }
}