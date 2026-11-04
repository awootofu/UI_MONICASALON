namespace UAS_APP_MONICASALON
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            UserAppTheme = AppTheme.Light;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = new Window(new AppShell());

#if WINDOWS
            // Open at a comfortable desktop size that keeps the whole login
            // screen (including the forgot-password link) above the taskbar.
            var display = DeviceDisplay.Current.MainDisplayInfo;
            var screenWidth = display.Width / display.Density;
            var screenHeight = display.Height / display.Density;

            window.Width = Math.Min(1150, screenWidth - 80);
            window.Height = Math.Min(760, screenHeight - 100);
            window.X = (screenWidth - window.Width) / 2;
            window.Y = (screenHeight - window.Height) / 2;
#endif

            return window;
        }
    }
}
