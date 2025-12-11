using System.Collections.ObjectModel;
using Avalonia.Controls;
using BorderDragNDropSample.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BorderDragNDropSample.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private ObservableCollection<DragItemViewModel> _items = [];

    public MainWindowViewModel()
    {
        // Добавляем тестовые данные
        for (var i = 1; i <= 4; i++)
        {
            Items.Add(new DragItemViewModel { Title = $"Элемент {i}" });
        }
    }
}