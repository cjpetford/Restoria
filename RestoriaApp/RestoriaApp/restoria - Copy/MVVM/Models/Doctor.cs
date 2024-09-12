using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingAppRestoria.Services;

namespace BookingAppRestoria.MVVM.Models
{
    public class Doctor
    {
        private readonly DatabaseService _databaseService;

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string Qualifications { get; set; } = string.Empty;
    }    
}
