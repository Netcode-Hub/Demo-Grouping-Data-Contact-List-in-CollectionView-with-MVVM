
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DemoContactApp.Services;

namespace DemoContactApp.ViewModels
{
    public partial class AddContactViewModel : CommunityToolkit.Mvvm.ComponentModel.ObservableObject
    {
        private readonly IContactService contactService;

        [ObservableProperty]
        private Models.Contact _contactModel;
    
        public AddContactViewModel(IContactService contactService)
        {
            this.contactService = contactService;
            ContactModel = new Models.Contact();
        }



        [RelayCommand]
        public async Task AddContactMethod()
        {
            if (ContactModel is null)
                return;

            char firstChar = ContactModel.Name.FirstOrDefault();
            ContactModel.Category = firstChar.ToString().ToUpper();
            var result = await contactService.AddContact(ContactModel);

            if (result > 0)
                CreateToast("Contact Added");
            else
                CreateToast("Error occured whiles processing your request");
        }

        private async void CreateToast(string v)
        {
            CancellationTokenSource cancellationTokenSource = new();

            string text = v;
            ToastDuration duration = ToastDuration.Long;
            double fontSize = 16;

            var toast = Toast.Make(text, duration, fontSize);
            await toast.Show(cancellationTokenSource.Token);
        }
    }
}
