using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using UAS_APP_MONICASALON.Models.Admin;

namespace UAS_APP_MONICASALON.ViewModels.Admin;

public partial class AdminBookingsViewModel : ObservableObject
{
    private readonly List<AdminBooking> _allBookings;

    public IList<string> DateFilters { get; } = new List<string>
    {
        "Semua Tanggal",
        "Hari Ini",
        "Minggu Ini",
        "Bulan Ini"
    };

    public IList<string> StatusFilters { get; } = new List<string>
    {
        "Semua Status",
        "Menunggu",
        "Dikonfirmasi",
        "Berlangsung",
        "Selesai",
        "Dibatalkan"
    };

    public ObservableCollection<AdminBooking> FilteredBookings { get; } = new();

    [ObservableProperty]
    public partial string SearchText { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string? SelectedDateFilter { get; set; } = "Semua Tanggal";

    [ObservableProperty]
    public partial string? SelectedStatusFilter { get; set; } = "Semua Status";

    [ObservableProperty]
    public partial string ResultsText { get; set; } = string.Empty;

    [ObservableProperty]
    public partial bool HasActiveFilters { get; set; }

    [ObservableProperty]
    public partial AdminBooking? SelectedBooking { get; set; }

    [ObservableProperty]
    public partial bool IsDetailOpen { get; set; }

    public AdminBookingsViewModel()
    {
        _allBookings = AdminMockData
            .CreateBookings()
            .OrderByDescending(booking => booking.AppointmentAt)
            .ToList();

        ApplyFilters();
    }

    partial void OnSearchTextChanged(string value) => ApplyFilters();

    partial void OnSelectedDateFilterChanged(string? value) => ApplyFilters();

    partial void OnSelectedStatusFilterChanged(string? value) => ApplyFilters();

    private void ApplyFilters()
    {
        var search = SearchText?.Trim() ?? string.Empty;
        var dateFilter = SelectedDateFilter ?? DateFilters[0];
        var statusFilter = SelectedStatusFilter ?? StatusFilters[0];

        IEnumerable<AdminBooking> query = _allBookings;

        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(booking =>
                booking.CustomerName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                booking.CustomerPhone.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                booking.ServiceName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                booking.StaffName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                booking.Id.Contains(search, StringComparison.OrdinalIgnoreCase));
        }

        var today = DateTime.Today;
        var weekStart = GetWeekStart(today);

        query = dateFilter switch
        {
            "Hari Ini" => query.Where(booking => booking.AppointmentAt.Date == today),
            "Minggu Ini" => query.Where(booking =>
                booking.AppointmentAt >= weekStart &&
                booking.AppointmentAt < weekStart.AddDays(7)),
            "Bulan Ini" => query.Where(booking =>
                booking.AppointmentAt.Year == today.Year &&
                booking.AppointmentAt.Month == today.Month),
            _ => query
        };

        BookingStatus? status = statusFilter switch
        {
            "Menunggu" => BookingStatus.Pending,
            "Dikonfirmasi" => BookingStatus.Confirmed,
            "Berlangsung" => BookingStatus.InProgress,
            "Selesai" => BookingStatus.Completed,
            "Dibatalkan" => BookingStatus.Cancelled,
            _ => null
        };

        if (status.HasValue)
        {
            query = query.Where(booking => booking.Status == status.Value);
        }

        var results = query.ToList();

        FilteredBookings.Clear();
        foreach (var booking in results)
        {
            FilteredBookings.Add(booking);
        }

        ResultsText = $"Menampilkan {results.Count} dari {_allBookings.Count} booking";
        HasActiveFilters =
            !string.IsNullOrWhiteSpace(search) ||
            dateFilter != DateFilters[0] ||
            statusFilter != StatusFilters[0];
    }

    [RelayCommand]
    private void ShowDetail(AdminBooking? booking)
    {
        if (booking is null)
        {
            return;
        }

        SelectedBooking = booking;
        IsDetailOpen = true;
    }

    [RelayCommand]
    private void CloseDetail()
    {
        IsDetailOpen = false;
    }

    [RelayCommand]
    private void ClearFilters()
    {
        SearchText = string.Empty;
        SelectedDateFilter = DateFilters[0];
        SelectedStatusFilter = StatusFilters[0];
    }

    [RelayCommand]
    private async Task ContactCustomerAsync()
    {
        if (SelectedBooking is null)
        {
            return;
        }

        await ShowInfoAsync(
            "Hubungi Pelanggan",
            $"{SelectedBooking.CustomerName}\n{SelectedBooking.CustomerPhone}\n\nIntegrasi WhatsApp akan hadir pada fase berikutnya.");
    }

    [RelayCommand]
    private async Task NewBookingAsync()
    {
        await ShowInfoAsync(
            "Booking Baru",
            "Form booking baru akan hadir pada fase berikutnya.");
    }

    private static DateTime GetWeekStart(DateTime date) =>
        date.AddDays(-(((int)date.DayOfWeek + 6) % 7));

    private static async Task ShowInfoAsync(string title, string message)
    {
        if (Shell.Current?.CurrentPage is Page page)
        {
            await page.DisplayAlertAsync(title, message, "OK");
        }
    }
}
