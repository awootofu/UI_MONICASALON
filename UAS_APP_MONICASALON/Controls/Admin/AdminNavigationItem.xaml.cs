using System.Windows.Input;

namespace UAS_APP_MONICASALON.Controls.Admin;

public partial class AdminNavigationItem : ContentView
{
    public static readonly BindableProperty TitleProperty = BindableProperty.Create(
        nameof(Title),
        typeof(string),
        typeof(AdminNavigationItem),
        string.Empty);

    public static readonly BindableProperty IconGlyphProperty = BindableProperty.Create(
        nameof(IconGlyph),
        typeof(string),
        typeof(AdminNavigationItem),
        string.Empty);

    public static readonly BindableProperty RouteProperty = BindableProperty.Create(
        nameof(Route),
        typeof(string),
        typeof(AdminNavigationItem),
        string.Empty);

    public static readonly BindableProperty IsActiveProperty = BindableProperty.Create(
        nameof(IsActive),
        typeof(bool),
        typeof(AdminNavigationItem),
        false);

    public static readonly BindableProperty CommandProperty = BindableProperty.Create(
        nameof(Command),
        typeof(ICommand),
        typeof(AdminNavigationItem));

    public AdminNavigationItem()
    {
        InitializeComponent();
    }

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public string IconGlyph
    {
        get => (string)GetValue(IconGlyphProperty);
        set => SetValue(IconGlyphProperty, value);
    }

    public string Route
    {
        get => (string)GetValue(RouteProperty);
        set => SetValue(RouteProperty, value);
    }

    public bool IsActive
    {
        get => (bool)GetValue(IsActiveProperty);
        set => SetValue(IsActiveProperty, value);
    }

    public ICommand? Command
    {
        get => (ICommand?)GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }

    private void OnTapped(object? sender, TappedEventArgs e)
    {
        if (Command is null || !Command.CanExecute(Route))
        {
            return;
        }

        Command.Execute(Route);
    }
}
