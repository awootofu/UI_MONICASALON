namespace UAS_APP_MONICASALON.Models;

public class BannerItem
{
    public string Title { get; set; } = string.Empty;

    public string Subtitle { get; set; } = string.Empty;

    public string Badge { get; set; } = string.Empty;

    public string ImageSource { get; set; } = string.Empty;

    public bool HasImage => !string.IsNullOrWhiteSpace(ImageSource);

    public bool ShowFallback => !HasImage;
}
