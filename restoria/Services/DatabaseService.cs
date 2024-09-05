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
        await _database.CreateTableAsync<Doctor>();
    }

    public async Task AddUserAsync(User user)
    {
        await _database.InsertAsync(user);
    }

    public async Task<User> GetUserByEmailAndPasswordAsync(string email, string password)
    {
        return await _database.Table<User>().Where(u => u.Email == email && u.Password == password).FirstOrDefaultAsync();
    }

    // New Methods for Doctor Entries
    public async Task AddDoctorAsync(Doctor doctor)
    {
        await _database.InsertAsync(doctor);
    }

    public async Task<List<Doctor>> GetDoctorsAsync()
    {
        return await _database.Table<Doctor>().ToListAsync();
    }
    
    public async Task<Doctor> GetDoctorAsync(int Id)
    {
        return await _database.Table<Doctor>().Where(d => d.Id == Id).FirstOrDefaultAsync();
    }

    public async Task<bool> AnyDoctorsAsync()
    {
        var count = await _database.Table<Doctor>().CountAsync();
        return count > 0;
    }

    public async Task AddAppointmentAsync(int userId, Doctor doctor, DateTime appointmentDate, TimeSpan appointmentTime)//Can't you see I'm burning, burning
    {
        Appointment appointment = new Appointment { UserID = userId, DoctorID = doctor.Id, AppointmentDate = appointmentDate, AppointmentTime = appointmentTime };
        await _database.InsertAsync(appointment);
    }
}
