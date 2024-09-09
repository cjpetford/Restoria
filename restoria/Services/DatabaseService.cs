using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingAppRestoria.MVVM.Models;

namespace BookingAppRestoria.Services
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _database;

        public DatabaseService()
        {
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Restoria4.db");
            _database = new SQLiteAsyncConnection(databasePath);

            _database.CreateTableAsync<User>();
            _database.CreateTableAsync<Doctor>();
        }

        // ===========================================================
        // =============== USER IN DB SECTION =======================
  
        public async Task AddUserAsync(User user)
        {
            await _database.InsertAsync(user);
        }

        public async Task<User> GetUserByEmailAndPasswordAsync(string email, string password)
        {
            return await _database.Table<User>().Where(u => u.Email == email && u.Password == password).FirstOrDefaultAsync();
        }


        // ===========================================================
        // =============== DOCTOR IN DB SECTION =======================
        public async Task<int> SaveDoctorAsync(Doctor doctor)
        {
            if (doctor.Id == 0) // Assuming Id is 0 for new entries
            {
                // Insert new doctor
                return await _database.InsertAsync(doctor);
            }
            else
            {
                // Update existing doctor
                return await _database.UpdateAsync(doctor);
            }
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
      

        public Task<int> DeleteDoctorAsync(Doctor doctor)
        {
            return _database.DeleteAsync(doctor);
        }


        // ===================================================================
        // =============== APPOINTMENT BOOKING SECTION =======================
        public async Task AddAppointmentAsync(Doctor doctor, DateTime appointmentDate, TimeSpan appointmentTime)
        {
            Appointment appointment = new Appointment { DoctorID = doctor.Id, AppointmentDate = appointmentDate, AppointmentTime = appointmentTime };
            await _database.InsertAsync(appointment);
        }
    }
}
