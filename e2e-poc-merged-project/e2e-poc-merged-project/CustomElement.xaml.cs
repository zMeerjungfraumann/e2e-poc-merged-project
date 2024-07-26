namespace e2e_poc_merged_project;

public partial class CustomElement : ContentView
{
	public CustomElement()
	{
		InitializeComponent();
	}
	public void onClick(object sender, EventArgs e)
	{
		customtext.Text = "Button Clicked";
	}
}