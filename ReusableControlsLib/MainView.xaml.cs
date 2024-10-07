using System.Windows.Controls;
using System.Windows.Media;

namespace ReusableControlsLib;

/// <summary>
/// Interaction logic for MainView.xaml
/// </summary>
public partial class MainView : UserControl
{
    public delegate void NavigationEventHandler(object? target);
    public event NavigationEventHandler NavigateBackEvent;
    public event NavigationEventHandler NavigateForewardEvent;

    public ILogger Logger;




    public MainView()
    {
        InitializeComponent();

        MainNavigationButtonBackwards.Click += (s, e) => NavigateBackEvent?.Invoke(null);
        MainNavigationButtonForewards.Click += (s, e) => NavigateForewardEvent?.Invoke(null);

        Logger = DebugBox;


        var head = new TreeViewItem
        {
            Header = "Fruits",
            ItemsSource = new List<RCL_TreeViewItem>
            {
                new("Apple", () => DebugBox.LogLine("Apple clicked", Brushes.Red), [ "Jonagold", "Jazz", "Green" ] ),
                new("Pear", () => DebugBox.LogLine("Pear clicked", Brushes.Orange), [ "Brown", "Green" ] ),
                new("Banana", () => DebugBox.LogLine("Banana clicked", ILogger.Options.BoldAndItalic), [ "Platano", "Regular", "Chiquita" ] ),
                new("Kiwi", () => DebugBox.LogLine("Kiwi clicked", Brushes.DarkGreen, ILogger.Options.Strikethrough), [ "Green", "Gold" ] )
            }
        };

        ItemTree.Items.Add(head);


        NavigateBackEvent += (t) => DebugBox.LogLine("Navigating backwards ...", Brushes.Gray, ILogger.Options.Italic);
        NavigateForewardEvent += (t) => DebugBox.LogLine("Navigating forwards ...", Brushes.Gray, ILogger.Options.Italic);
    }
}

public class RCL_TreeViewItem : TreeViewItem, IViewable
{
    public RCL_TreeViewItem(string header, Action doubleClickAction, List<string> contextMenuOptions)
    {
        Header = header;
        MouseDoubleClick += (s, e) => doubleClickAction?.Invoke();

        ContextMenu = new ContextMenu();

        foreach (var item in contextMenuOptions)
            ContextMenu.Items.Add(new MenuItem { Header = item });
    }

    public object GetView() => new StackPanel() { Background = Brushes.Red };
}

public class RCL_TreeViewItem_2 : TreeViewItem, IViewable
{
    private Brush brush;

    public RCL_TreeViewItem_2(string header, Brush color)
    {
        Header = header;
        brush = color;
    }

    public object GetView() => new StackPanel() { Background = brush };
}

public interface IViewable
{
    object GetView();
}

public interface IOptionable
{
    object GetOptions();
}

public interface IContextMenuHolder
{
    ContextMenu GetContextMenu();
}

public class DataPageContainer : IViewable, IContextMenuHolder, IOptionable
{
    public ContextMenu GetContextMenu()
    {
        throw new NotImplementedException();
    }

    public object GetOptions()
    {
        throw new NotImplementedException();
    }

    public object GetView()
    {
        throw new NotImplementedException();
    }
}