Example of a .NET MAUI application that creates a form with input fields for "Name" and "Quantity" and saves the data to an SQLite database.

1. **Create a new .NET MAUI project**:
   ```bash
   dotnet new maui -n MyMauiApp
   cd MyMauiApp
   ```

2. **Add SQLite NuGet package**:
   ```bash
   dotnet add package sqlite-net-pcl
   ```

3. **Modify the `MainPage.xaml` to include the form**:
   ```xml
   <ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
                xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
                x:Class="MyMauiApp.MainPage">

       <StackLayout Padding="30">
           <Label Text="Name" />
           <Entry x:Name="NameEntry" />

           <Label Text="Quantity" />
           <Entry x:Name="QuantityEntry" Keyboard="Numeric" />

           <Button Text="Save" Clicked="OnSaveClicked" />
       </StackLayout>
   </ContentPage>
   ```

4. **Modify the `MainPage.xaml.cs` to handle the form submission and save to SQLite**:
   ```csharp
   using SQLite;
   using System.IO;

   namespace MyMauiApp
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
   ```

This example demonstrates a basic form with "Name" and "Quantity" fields, and saves the input to an SQLite database when the "Save" button is clicked.
