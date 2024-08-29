using SQLite;
using System.Threading.Tasks;
using System.Collections.Generic;
using restoria.MVVM.Models;
public class DatabaseService
{
    private readonly SQLiteAsyncConnection _database;

    public DatabaseService()
    {
        var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "userroles.db");
        _database = new SQLiteAsyncConnection(databasePath);
    }

    public async Task InitializeAsync()
    {
        await _database.CreateTableAsync<User>();
    }

    public async Task AddUserAsync(User user)
    {
        await _database.InsertAsync(user);
    }

    public async Task<User> GetUserByEmailAndPasswordAsync(string email, string password)
    {
        return await _database.Table<User>().Where(u => u.Email == email && u.Password == password).FirstOrDefaultAsync();
    }
}
