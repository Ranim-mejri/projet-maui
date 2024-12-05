namespace MauiApp1112.view;

public partial class NewPage1 : ContentPage
{
	public NewPage1()
	{
		InitializeComponent();
        BindingContext = new ViewModel.ViewModelPage1();

    }


}