using System.Globalization;

namespace UAS_APP_MONICASALON.Models;

public class ServiceItem
{
    public string Name { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public string Duration { get; set; } = string.Empty;

    public string Rating { get; set; } = "4.8";

    public string IconGlyph { get; set; } = string.Empty;

    public string Description { get; set; } =
        "Perawatan dengan bahan premium, konsultasi gaya rambut gratis dengan stylist Monica Salon.";

    public string FormattedPrice =>
        $"Rp {Price.ToString("N0", CultureInfo.InvariantCulture).Replace(",", ".")}";

    public string RatingText => $"{Rating}/5.0";
}
