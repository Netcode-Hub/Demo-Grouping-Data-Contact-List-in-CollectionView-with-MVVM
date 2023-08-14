using DemoContactApp.ViewModels;

namespace DemoContactApp.Views;

public partial class HomePage : ContentPage
{
    private readonly HomePageViewModel homePageViewModel;

    public HomePage(HomePageViewModel homePageViewModel)
	{
		InitializeComponent();
		BindingContext = homePageViewModel;
        this.homePageViewModel = homePageViewModel;
    }

    protected override void OnAppearing()
    {
        homePageViewModel.GetMyContactsCommand.Execute(null);
        base.OnAppearing();
        
    }
}