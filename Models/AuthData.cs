using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПРОЕКТ2.Models
{
    class AuthData
    {
        private static AuthData instance;

        public static AuthData Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AuthData();
                }
                return instance;
            }
        }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public bool IsAdmin { get; set; } // Добавление свойства IsAdmin

        private AuthData() // Конструктор сделан закрытым
        {
            // Здесь можно инициализировать свойства, если необходимо
        }
    }
}
