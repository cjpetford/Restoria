using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restoria.MVVM.Models
{
    public class Appointment
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int userId { get; set; }
        public int doctorId { get; set; }
        public DateTime AppointmentDate { get; set; }

    }
}