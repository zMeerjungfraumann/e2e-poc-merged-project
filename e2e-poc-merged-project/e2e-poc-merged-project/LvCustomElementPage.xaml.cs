using System.Collections.ObjectModel;

namespace e2e_poc_merged_project;

public partial class LvCustomElementPage : ContentPage
{
    public ObservableCollection<TestItem> TestItems { get; set; }
    public LvCustomElementPage()
	{
		InitializeComponent();
        TestItems = new ObservableCollection<TestItem>
            {
                new TestItem { Name = "Test Item 1", AutomationId = "item1" },
                new TestItem { Name = "Test Item 2", AutomationId = "item2" },
                new TestItem { Name = "Test Item 3", AutomationId = "item3" }
            };

        TestListView.ItemsSource = TestItems;
    }
    public class TestItem
    {
        public string Name { get; set; }
        public string AutomationId { get; set; }
    }
}