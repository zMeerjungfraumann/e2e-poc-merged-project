namespace e2e_poc_merged_project;

public partial class LoggedInPage : ContentPage
{
    public LoggedInPage()
    {
        InitializeComponent();
    }

    public async void showMonkeys(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CvMonkeysPage()); //Navigate to carouselview (monkeys) page

    }

    public async void showCbSlider(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CbSliderPage()); //Navigate to checkbox and slider page

    }

    public async void showLVCustomElement(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LvCustomElementPage()); //Navigate to listview/custom element page

    }

    public async void showComboBox(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PickerPage()); //Navigate to combobox page

    }
}