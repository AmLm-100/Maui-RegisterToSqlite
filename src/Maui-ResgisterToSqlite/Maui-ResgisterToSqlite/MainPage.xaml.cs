using SQLite;
using System.IO;

namespace Maui_ResgisterToSqlite
{
    public partial class MainPage : ContentPage
    {
        private SQLiteConnection _database;

        public MainPage()
        {
            InitializeComponent();

            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "mydatabase.db3");
            _database = new SQLiteConnection(dbPath);
            _database.CreateTable<Item>();
        }

        private void OnSaveClicked(object sender, EventArgs e)
        {
            var item = new Item
            {
                Name = NameEntry.Text,
                Quantity = int.Parse(QuantityEntry.Text)
            };
            _database.Insert(item);
            DisplayAlert("Success", "Item saved", "OK");

            // Clear the entries
            NameEntry.Text = string.Empty;
            QuantityEntry.Text = string.Empty;

            NameEntry.Focus();
        }
    }
    public class Item
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
    }

}
