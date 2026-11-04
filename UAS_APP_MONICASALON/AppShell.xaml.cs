using UAS_APP_MONICASALON.Views;
using UAS_APP_MONICASALON.Views.Admin;

namespace UAS_APP_MONICASALON
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
            Routing.RegisterRoute(nameof(HomeCustomerPage), typeof(HomeCustomerPage));
            Routing.RegisterRoute(nameof(AdminDashboardPage), typeof(AdminDashboardPage));
            Routing.RegisterRoute(nameof(AdminBookingsPage), typeof(AdminBookingsPage));
        }
    }
}
