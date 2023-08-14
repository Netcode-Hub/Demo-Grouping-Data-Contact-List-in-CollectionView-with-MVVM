using CommunityToolkit.Mvvm.ComponentModel;
using DemoContactApp.ViewModels;
using System.Security.Cryptography.X509Certificates;

namespace DemoContactApp.Views;

public partial class AddContactPage : ContentPage
{
    
    public AddContactPage(AddContactViewModel addContactViewModel)
	{
		InitializeComponent();
		BindingContext =addContactViewModel;
    }
    
}