
using CommunityToolkit.Mvvm.Input;
using DemoContactApp.Views;
using MvvmHelpers;
using DemoContactApp.Models;
using DemoContactApp.Services;
using System.Collections.ObjectModel;

namespace DemoContactApp.ViewModels
{
    public partial class HomePageViewModel : CommunityToolkit.Mvvm.ComponentModel.ObservableObject
    {
        public ObservableCollection<Models.ContactGroup> MyGroupContacts { get; set; } = new();

        private readonly IContactService contactService;

        public HomePageViewModel(IContactService contactService)
        {
            this.contactService = contactService;
            GetMyContacts();
        }

        [RelayCommand]
        public async Task GetMyContacts()
        {
            var result = await contactService.GetContacts();
            if (result is null)
                return;

            MyGroupContacts.Clear();
            var dic = (result.OrderBy(x => x.Name).GroupBy(o => o.Name.Substring(0, 1)).ToDictionary(g => g.Key, g => g.ToList()));
            foreach (KeyValuePair<string, List<Models.Contact>> item in dic)
            {
                MyGroupContacts.Add(new ContactGroup(item.Key, new List<Models.Contact>(item.Value)));
            }

        }

        [RelayCommand]
        public async Task AddContact()
        {
            await Shell.Current.GoToAsync(nameof(AddContactPage));
        }


    }
}
