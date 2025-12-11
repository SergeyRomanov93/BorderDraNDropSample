using CommunityToolkit.Mvvm.ComponentModel;

namespace BorderDragNDropSample.ViewModels;

public partial class DragItemViewModel : ViewModelBase
{
    [ObservableProperty] private string _title;
}