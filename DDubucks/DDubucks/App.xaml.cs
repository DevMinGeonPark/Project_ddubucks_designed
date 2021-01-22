using Prism;
using Prism.Ioc;
using Prism.Unity;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DDubucks.Services.Authentication;
using DDubucks.Views;


[assembly: ExportFont("SCDream4.ttf", Alias = "RegularFont")]
[assembly: ExportFont("SCDream8.ttf", Alias = "BoldFont")]

namespace DDubucks
{
    public partial class App : PrismApplication
    {
        /* 
        * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
        * This imposes a limitation in which the App class must have a default constructor. 
        * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
        */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("app:///LottieAnimationPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAuthenticationService, AuthenticationService>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage>();
            containerRegistry.RegisterForNavigation<LoginPage>();
            containerRegistry.RegisterForNavigation<LottieAnimationPage>();
            containerRegistry.RegisterForNavigation<TestPage>();
            containerRegistry.RegisterForNavigation<MyPage>();


        }
    }
}
