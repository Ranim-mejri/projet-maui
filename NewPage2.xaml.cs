namespace MauiApp1112.view;

public partial class NewPage2 : ContentPage
{
	public NewPage2()
	{
		InitializeComponent();
        BindingContext = new ViewModel.ViewModelPage2();

    }
}