using UAS_APP_MONICASALON.Views;

namespace UAS_APP_MONICASALON
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
            Routing.RegisterRoute(nameof(HomeCustomerPage), typeof(HomeCustomerPage));
        }
    }
}
