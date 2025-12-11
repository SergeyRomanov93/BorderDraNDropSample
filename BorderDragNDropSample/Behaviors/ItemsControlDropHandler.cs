using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.VisualTree;
using Avalonia.Xaml.Interactions.DragAndDrop;
using BorderDragNDropSample.ViewModels;

namespace BorderDragNDropSample.Behaviors;

public class ItemsControlDropHandler : DropHandlerBase
{
    private bool Validate<T>(ItemsControl itemsControl, DragEventArgs e, object? sourceContext, object? targetContext, bool bExecute) where T : DragItemViewModel
    {
        if (sourceContext is not T sourceItem
            || targetContext is not MainWindowViewModel vm
            || itemsControl.GetVisualAt(e.GetPosition(itemsControl)) is not Control targetControl
            || targetControl.DataContext is not T targetItem)
        {
            return false;
        }

        var items = vm.Items;
        var sourceIndex = items.IndexOf(sourceItem);
        var targetIndex = items.IndexOf(targetItem);

        if (sourceIndex < 0 || targetIndex < 0)
        {
            return false;
        }

        switch (e.DragEffects)
        {
            case DragDropEffects.Copy:
            {
                if (bExecute)
                {
                    var clone = new DragItemViewModel() { Title = sourceItem.Title + "_copy" };
                    InsertItem(items, clone, targetIndex + 1);
                }
                return true;
            }
            case DragDropEffects.Move:
            {
                if (bExecute)
                {
                    MoveItem(items, sourceIndex, targetIndex);
                }
                return true;
            }
            case DragDropEffects.Link:
            {
                if (bExecute)
                {
                    MoveItem(items, sourceIndex, targetIndex);
                }
                return true;
            }
            default:
                return false;
        }
    }
    
    public override bool Validate(object? sender, DragEventArgs e, object? sourceContext, object? targetContext, object? state)
    {
        if (e.Source is Control && sender is ItemsControl itemsControl)
        {
            return Validate<DragItemViewModel>(itemsControl, e, sourceContext, targetContext, false);
        }
        return false;
    }

    public override bool Execute(object? sender, DragEventArgs e, object? sourceContext, object? targetContext, object? state)
    {
        if (e.Source is Control && sender is ItemsControl itemsControl)
        {
            return Validate<DragItemViewModel>(itemsControl, e, sourceContext, targetContext, true);
        }
        return false;
    }
}