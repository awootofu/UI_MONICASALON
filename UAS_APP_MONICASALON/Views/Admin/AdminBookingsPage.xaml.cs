using UAS_APP_MONICASALON.ViewModels.Admin;
using UraniumUI.Controls;
using UraniumUI.Pages;

namespace UAS_APP_MONICASALON.Views.Admin;

public partial class AdminBookingsPage : UraniumContentPage
{
    public AdminBookingsPage()
        : this(new AdminBookingsViewModel())
    {
    }

    public AdminBookingsPage(AdminBookingsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    private void OnCalendarDateSelected(object? sender, CalendarDateSelectedEventArgs e)
    {
        if (BindingContext is AdminBookingsViewModel viewModel)
        {
            viewModel.IsCalendarOpen = false;
        }
    }
}
