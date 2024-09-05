using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingAppRestoria.MVVM.Models
{
    public class Doctor
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string Qualifications { get; set; }
    }
}
