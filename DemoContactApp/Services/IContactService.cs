
using DemoContactApp.Models;
namespace DemoContactApp.Services
{
    public interface IContactService
    {
        Task<int> AddContact(Models.Contact contact);
        Task<List<Models.Contact>> GetContacts();
    }
}
