using System;
using BorderDragNDropSample.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;

namespace BorderDragNDropSample.Models;

public partial class DraggableItemViewModel : ViewModelBase
{
    [ObservableProperty]
    private string title = string.Empty;

    [ObservableProperty]
    private bool isBeingDragged;

    public Guid Id { get; } = Guid.NewGuid();
}