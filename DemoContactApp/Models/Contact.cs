using SQLite;
namespace DemoContactApp.Models
{
    public class Contact
    {
        

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public string Category { get; set; }
    }
}
