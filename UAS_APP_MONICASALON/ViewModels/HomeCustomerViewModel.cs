using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using UAS_APP_MONICASALON.Icons;
using UAS_APP_MONICASALON.Models;

namespace UAS_APP_MONICASALON.ViewModels;

public partial class HomeCustomerViewModel : ObservableObject
{
    public ObservableCollection<BannerItem> Banners { get; } = new();

    public ObservableCollection<CategoryItem> Categories { get; } = new();

    public ObservableCollection<ServiceItem> FavoriteServices { get; } = new();

    [ObservableProperty]
    public partial string SearchText { get; set; } = string.Empty;

    [ObservableProperty]
    public partial ServiceItem? SelectedService { get; set; }

    [ObservableProperty]
    public partial CategoryItem? SelectedCategory { get; set; }

    [ObservableProperty]
    public partial bool IsServiceDetailOpen { get; set; }

    public HomeCustomerViewModel()
    {
        LoadMockData();
    }

    private void LoadMockData()
    {
        Banners.Add(new BannerItem
        {
            Title = "Kini Monica Salon Sudah Ada Aplikasi!",
            Subtitle = "Booking perawatan favoritmu sekarang lebih mudah, cepat, dan praktis!",
            Badge = "# Buka Setiap Hari",
            ImageSource = "banner_aplikasi.png"
        });

        Banners.Add(new BannerItem
        {
            Title = "Kini Bisa Booking 24 Jam!",
            Subtitle = "Atur jadwal perawatanmu kapan saja tanpa antre.",
            Badge = "# Buka 24/7",
            ImageSource = "banner_booking24jam.png"
        });

        Categories.Add(new CategoryItem { Name = "Potong Rambut", IconGlyph = MaterialRegular.Content_cut });
        Categories.Add(new CategoryItem { Name = "Creambath", IconGlyph = MaterialRegular.Spa });
        Categories.Add(new CategoryItem { Name = "Smoothing", IconGlyph = MaterialRegular.Auto_awesome });
        Categories.Add(new CategoryItem { Name = "Pewarnaan", IconGlyph = MaterialRegular.Palette });
        Categories.Add(new CategoryItem { Name = "Facial", IconGlyph = MaterialRegular.Face_retouching_natural });

        FavoriteServices.Add(new ServiceItem
        {
            Name = "Potong Rambut",
            Price = 50000,
            Duration = "45 mnt",
            Rating = "4.8",
            IconGlyph = MaterialRegular.Content_cut
        });

        FavoriteServices.Add(new ServiceItem
        {
            Name = "Smoothing",
            Price = 250000,
            Duration = "2-3 jam",
            Rating = "4.8",
            IconGlyph = MaterialRegular.Auto_awesome
        });

        FavoriteServices.Add(new ServiceItem
        {
            Name = "Pewarnaan Rambut",
            Price = 200000,
            Duration = "2-3 jam",
            Rating = "4.9",
            IconGlyph = MaterialRegular.Palette
        });

        FavoriteServices.Add(new ServiceItem
        {
            Name = "Creambath",
            Price = 80000,
            Duration = "45 mnt",
            Rating = "4.7",
            IconGlyph = MaterialRegular.Spa
        });

        FavoriteServices.Add(new ServiceItem
        {
            Name = "Rebonding",
            Price = 300000,
            Duration = "3-4 jam",
            Rating = "4.8",
            IconGlyph = MaterialRegular.Straighten
        });

        FavoriteServices.Add(new ServiceItem
        {
            Name = "Facial",
            Price = 120000,
            Duration = "60 mnt",
            Rating = "4.7",
            IconGlyph = MaterialRegular.Face_retouching_natural
        });
    }

    [RelayCommand]
    private void SelectService(ServiceItem? service)
    {
        if (service is null)
        {
            return;
        }

        SelectedService = service;
        IsServiceDetailOpen = true;
    }

    [RelayCommand]
    private void SelectCategory(CategoryItem? category)
    {
        SelectedCategory = category;
    }

    [RelayCommand]
    private void CloseServiceDetail()
    {
        IsServiceDetailOpen = false;
    }

    [RelayCommand]
    private async Task BookServiceAsync()
    {
        if (SelectedService is null)
        {
            return;
        }

        var serviceName = SelectedService.Name;
        IsServiceDetailOpen = false;

        await ShowInfoAsync(
            "Booking Sekarang",
            $"Layanan {serviceName} siap dibooking. Fitur booking lengkap akan hadir pada fase berikutnya.");
    }

    [RelayCommand]
    private async Task OpenNotificationsAsync()
    {
        await ShowInfoAsync("Notifikasi", "Belum ada notifikasi baru untukmu.");
    }

    [RelayCommand]
    private async Task FilterAsync()
    {
        await ShowInfoAsync("Filter", "Filter layanan akan hadir pada fase berikutnya.");
    }

    [RelayCommand]
    private async Task SeeAllServicesAsync()
    {
        await ShowInfoAsync("Layanan", "Semua layanan Monica Salon akan tampil di sini.");
    }

    [RelayCommand]
    private async Task NavigateTabAsync(string? tab)
    {
        if (string.IsNullOrWhiteSpace(tab) || tab == "Home")
        {
            return;
        }

        await ShowInfoAsync(tab, $"Halaman {tab} akan hadir pada fase berikutnya.");
    }

    private static async Task ShowInfoAsync(string title, string message)
    {
        if (Shell.Current?.CurrentPage is Page page)
        {
            await page.DisplayAlertAsync(title, message, "OK");
        }
    }
}
