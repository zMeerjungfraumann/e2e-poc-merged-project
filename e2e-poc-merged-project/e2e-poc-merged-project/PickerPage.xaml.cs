namespace e2e_poc_merged_project;

public partial class PickerPage : ContentPage
{
	public PickerPage()
	{
		InitializeComponent();
        BindingContext = new MonthsViewModel();
       
    }
}