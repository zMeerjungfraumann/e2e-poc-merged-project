namespace e2e_poc_merged_project;

public partial class CbSliderPage : ContentPage
{
	public CbSliderPage()
	{
		InitializeComponent();
	}
    private void OnCheckBoxChanged(object sender, EventArgs e)
    {
        
        if(ch_Check.IsChecked)
        {
            btn_Disabled.IsEnabled = true;
        }
        else
        {
            btn_Disabled.IsEnabled = false;
        }
    }
}