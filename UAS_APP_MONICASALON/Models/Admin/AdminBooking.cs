using System.Globalization;
using CommunityToolkit.Mvvm.ComponentModel;

namespace UAS_APP_MONICASALON.Models.Admin;

public partial class AdminBooking : ObservableObject
{
    private static readonly CultureInfo IndonesianCulture = CultureInfo.GetCultureInfo("id-ID");

    public string Id { get; init; } = string.Empty;

    public string CustomerName { get; init; } = string.Empty;

    public string CustomerPhone { get; init; } = string.Empty;

    public string ServiceName { get; init; } = string.Empty;

    public string StaffName { get; init; } = string.Empty;

    public int DurationMinutes { get; init; }

    public decimal Price { get; init; }

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(DateText))]
    [NotifyPropertyChangedFor(nameof(TimeText))]
    [NotifyPropertyChangedFor(nameof(ScheduleText))]
    public partial DateTime AppointmentAt { get; set; }

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(StatusText))]
    public partial BookingStatus Status { get; set; }

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(PaymentStatusText))]
    public partial PaymentStatus PaymentStatus { get; set; }

    [ObservableProperty]
    public partial bool IsSlotLocked { get; set; }

    public string CustomerInitials =>
        string.Concat(CustomerName
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Take(2)
            .Select(part => char.ToUpperInvariant(part[0])));

    public string CustomerMeta => $"{Id} · {CustomerPhone}";

    public string DateText => AppointmentAt.ToString("dd MMM yyyy", IndonesianCulture);

    public string TimeText => AppointmentAt.ToString("HH:mm", IndonesianCulture);

    public string ScheduleText => $"{DateText} · {TimeText}";

    public string DurationText => DurationMinutes switch
    {
        < 60 => $"{DurationMinutes} menit",
        _ when DurationMinutes % 60 == 0 => $"{DurationMinutes / 60} jam",
        _ => $"{DurationMinutes / 60} jam {DurationMinutes % 60} menit"
    };

    public string StaffText => $"Stylist: {StaffName}";

    public string ServiceStaffText => $"{ServiceName} · {StaffName}";

    public string ServiceStaffPriceText => $"{ServiceName} · {StaffName} · {PriceText}";

    public string PriceText =>
        $"Rp {Price.ToString("N0", CultureInfo.InvariantCulture).Replace(",", ".")}";

    public string StatusText => Status switch
    {
        BookingStatus.Pending => "Menunggu",
        BookingStatus.Confirmed => "Dikonfirmasi",
        BookingStatus.Completed => "Selesai",
        BookingStatus.Rejected => "Ditolak",
        BookingStatus.Cancelled => "Dibatalkan",
        BookingStatus.NoShow => "Tidak Hadir",
        _ => string.Empty
    };

    public string PaymentStatusText => PaymentStatus switch
    {
        PaymentStatus.Paid => "Lunas",
        PaymentStatus.Refunded => "Dikembalikan",
        _ => "Belum Dibayar"
    };
}
