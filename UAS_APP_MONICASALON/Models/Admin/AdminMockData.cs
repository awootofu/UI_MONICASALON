namespace UAS_APP_MONICASALON.Models.Admin;

/// <summary>
/// UI-only booking data for the Admin screens. Dates are relative to today so
/// the "Hari Ini", "Minggu Ini", and "Bulan Ini" filters always have results.
/// </summary>
public static class AdminMockData
{
    public static IReadOnlyList<AdminBooking> CreateBookings()
    {
        var today = DateTime.Today;
        var monday = today.AddDays(-(((int)today.DayOfWeek + 6) % 7));

        return new List<AdminBooking>
        {
            Create("BK-1051", "Bella Anisa", "0812 3456 7890", "Potong Rambut", "Dewi", today.AddHours(9), 50000, BookingStatus.Completed),
            Create("BK-1052", "Siti Rahma", "0813 2345 6789", "Creambath", "Sari", today.AddHours(10), 80000, BookingStatus.Confirmed),
            Create("BK-1053", "Nadia Putri", "0857 1122 3344", "Smoothing", "Rina", today.AddHours(11).AddMinutes(30), 250000, BookingStatus.Pending),
            Create("BK-1054", "Ayu Lestari", "0821 5566 7788", "Facial", "Nadia", today.AddHours(13), 120000, BookingStatus.Confirmed),
            Create("BK-1055", "Kirana Dewi", "0899 8877 6655", "Smoothing", "Rina", today.AddHours(14), 250000, BookingStatus.InProgress),
            Create("BK-1056", "Rizky Pratama", "0812 9988 7766", "Potong Rambut", "Dewi", today.AddHours(15), 50000, BookingStatus.Pending),
            Create("BK-1057", "Maya Sari", "0838 4455 6677", "Pewarnaan Rambut", "Sari", today.AddHours(16).AddMinutes(30), 200000, BookingStatus.Confirmed),

            Create("BK-1058", "Intan Permata", "0856 7788 9900", "Rebonding", "Rina", today.AddDays(1).AddHours(10), 300000, BookingStatus.Pending),
            Create("BK-1059", "Dinda Maharani", "0817 3344 5566", "Creambath", "Nadia", today.AddDays(1).AddHours(13), 80000, BookingStatus.Confirmed),
            Create("BK-1060", "Farah Aulia", "0822 6677 8899", "Potong Rambut", "Dewi", today.AddDays(1).AddHours(15).AddMinutes(30), 50000, BookingStatus.Pending),

            Create("BK-1061", "Citra Dewi", "0813 5566 2211", "Facial", "Sari", today.AddDays(-1).AddHours(11), 120000, BookingStatus.Completed),
            Create("BK-1062", "Lina Marlina", "0857 8899 1122", "Smoothing", "Rina", today.AddDays(-1).AddHours(14), 250000, BookingStatus.Cancelled),

            Create("BK-1063", "Putri Handayani", "0812 1122 3344", "Potong Rambut", "Dewi", monday.AddHours(10), 50000, BookingStatus.Completed),
            Create("BK-1064", "Rani Oktaviani", "0838 2233 4455", "Creambath", "Sari", monday.AddHours(13), 80000, BookingStatus.Completed),
            Create("BK-1065", "Tika Lestari", "0821 3344 5566", "Facial", "Nadia", monday.AddDays(1).AddHours(9).AddMinutes(30), 120000, BookingStatus.Completed),
            Create("BK-1066", "Wulan Sari", "0899 4455 6677", "Pewarnaan Rambut", "Sari", monday.AddDays(1).AddHours(14), 200000, BookingStatus.Confirmed),

            Create("BK-1067", "Anisa Rahma", "0856 5566 7788", "Smoothing", "Rina", monday.AddDays(3).AddHours(11), 250000, BookingStatus.Confirmed),
            Create("BK-1068", "Fitri Nuraini", "0817 6677 8899", "Potong Rambut", "Dewi", monday.AddDays(3).AddHours(16), 50000, BookingStatus.Pending),
            Create("BK-1069", "Dewi Anggraini", "0822 7788 9900", "Creambath", "Sari", monday.AddDays(4).AddHours(10).AddMinutes(30), 80000, BookingStatus.Confirmed),
            Create("BK-1070", "Nabila Zahra", "0813 8899 0011", "Facial", "Nadia", monday.AddDays(5).AddHours(13).AddMinutes(30), 120000, BookingStatus.Pending),
            Create("BK-1071", "Zahra Amelia", "0857 9900 1122", "Rebonding", "Rina", monday.AddDays(6).AddHours(10), 300000, BookingStatus.Confirmed),
            Create("BK-1072", "Melati Kusuma", "0812 0011 2233", "Potong Rambut", "Dewi", monday.AddDays(6).AddHours(14).AddMinutes(30), 50000, BookingStatus.Pending),

            Create("BK-1073", "Bella Anisa", "0812 3456 7890", "Smoothing", "Rina", monday.AddDays(7).AddHours(10), 250000, BookingStatus.Confirmed),
            Create("BK-1074", "Sarah Wijaya", "0838 3344 5566", "Creambath", "Sari", monday.AddDays(8).AddHours(11), 80000, BookingStatus.Confirmed),
            Create("BK-1075", "Indah Permatasari", "0821 4455 6677", "Facial", "Nadia", monday.AddDays(9).AddHours(15), 120000, BookingStatus.Pending)
        };
    }

    private static AdminBooking Create(
        string id,
        string customerName,
        string customerPhone,
        string serviceName,
        string staffName,
        DateTime appointmentAt,
        decimal price,
        BookingStatus status) =>
        new()
        {
            Id = id,
            CustomerName = customerName,
            CustomerPhone = customerPhone,
            ServiceName = serviceName,
            StaffName = staffName,
            AppointmentAt = appointmentAt,
            Price = price,
            Status = status
        };
}
