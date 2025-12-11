using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using BorderDragNDropSample.ViewModels;

namespace BorderDragNDropSample.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        DataContext = new MainWindowViewModel();
    }
    
    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}