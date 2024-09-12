using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingAppRestoria.Services
{
    public class AdminLoginService
    {
        private const string AdminUsername = "administrator69";
        private const string AdminPassword = "theConnor!";

        public bool IsAdmin { get; private set; } = false;

        public bool ValidateAdminLogin(string username, string password)
        {
            if (username == AdminUsername && password == AdminPassword)
            {
                IsAdmin = true;
                return true;
            }
            else
            {
                IsAdmin = false;
                return false;
            }
        }

        // Admin privileges
        public void DeleteItem(int itemId)
        {
            if (IsAdmin)
            {
                // Perform deletion logic here
                Console.WriteLine($"Item {itemId} deleted.");
            }
            else
            {
                Console.WriteLine("You do not have admin privileges.");
            }
        }

        public void EditItem(int itemId, string newData)
        {
            if (IsAdmin)
            {
                // Perform edit logic here
                Console.WriteLine($"Item {itemId} updated with new data: {newData}");
            }
            else
            {
                Console.WriteLine("You do not have admin privileges.");
            }
        }

        public void ModifySettings(string newSetting)
        {
            if (IsAdmin)
            {
                // Perform modify logic here
                Console.WriteLine($"Settings modified: {newSetting}");
            }
            else
            {
                Console.WriteLine("You do not have admin privileges.");
            }
        }
    }

}
