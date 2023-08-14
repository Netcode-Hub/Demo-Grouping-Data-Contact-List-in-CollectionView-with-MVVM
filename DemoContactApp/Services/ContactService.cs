
using DemoContactApp.Models;
using SQLite;

namespace DemoContactApp.Services
{
    public class ContactService : IContactService
    {
        private SQLiteAsyncConnection connection;
        public ContactService()
        {
            SetUpDatabase();
        }

        public async Task<int> AddContact(Models.Contact contact) => await connection.InsertAsync(contact);

        public async Task<List<Models.Contact>> GetContacts() => await connection.Table<Models.Contact>().ToListAsync();  

        private async void SetUpDatabase()
        {
            if(connection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Contacts.db3");
                connection = new SQLiteAsyncConnection(dbPath);
                await connection.CreateTableAsync<Models.Contact>();
            }
        }
    }
}
