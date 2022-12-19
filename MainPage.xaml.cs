using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MauiIssuesApp;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

        for (int i = 0; i < 10; i++)
        {
            MenuItems.Add(new TestItem { Name = $"Button {i}", Description = (i * 10).ToString() });
        }
        CommandRemove = new Command(() =>
        {
            if (LineItems.Any())
            {
                if (LineItems.Count > 1) LineItems.RemoveAt(1);
                else LineItems.RemoveAt(0);
            }
        });
        BindingContext = this;
    }

    public ObservableCollection<TestItem> MenuItems { get; set; } = new ObservableCollection<TestItem>();
    public ObservableCollection<TestItem2> LineItems { get; set; } = new ObservableCollection<TestItem2>();

    public ICommand CommandRemove { get; set; }

    private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var mivm = (e.SelectedItem as TestItem);

        LineItems.Add(new TestItem2 { Nam = mivm.Name, Desc = mivm.Description });
    }
}

public class TestItem
{
    public string Name { get; set; }
    public string Description { get; set; }
}

public class TestItem2
{
    public string Nam { get; set; }
    public string Desc { get; set; }
}
