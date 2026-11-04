using System.Globalization;

namespace UAS_APP_MONICASALON.Models.Admin;

public class AdminBooking
{
    private static readonly CultureInfo IndonesianCulture = CultureInfo.GetCultureInfo("id-ID");

    public string Id { get; init; } = string.Empty;

    public string CustomerName { get; init; } = string.Empty;

    public string CustomerPhone { get; init; } = string.Empty;

    public string ServiceName { get; init; } = string.Empty;

    public string StaffName { get; init; } = string.Empty;

    public DateTime AppointmentAt { get; init; }

    public decimal Price { get; init; }

    public BookingStatus Status { get; init; }

    public string CustomerInitials =>
        string.Concat(CustomerName
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Take(2)
            .Select(part => char.ToUpperInvariant(part[0])));

    public string CustomerMeta => $"{Id} · {CustomerPhone}";

    public string DateText => AppointmentAt.ToString("dd MMM yyyy", IndonesianCulture);

    public string TimeText => AppointmentAt.ToString("HH:mm", IndonesianCulture);

    public string ScheduleText => $"{DateText} · {TimeText}";

    public string StaffText => $"Stylist: {StaffName}";

    public string ServiceStaffText => $"{ServiceName} · {StaffName}";

    public string ServiceStaffPriceText => $"{ServiceName} · {StaffName} · {PriceText}";

    public string PriceText =>
        $"Rp {Price.ToString("N0", CultureInfo.InvariantCulture).Replace(",", ".")}";

    public string StatusText => Status switch
    {
        BookingStatus.Pending => "Menunggu",
        BookingStatus.Confirmed => "Dikonfirmasi",
        BookingStatus.InProgress => "Berlangsung",
        BookingStatus.Completed => "Selesai",
        BookingStatus.Cancelled => "Dibatalkan",
        _ => string.Empty
    };
}
