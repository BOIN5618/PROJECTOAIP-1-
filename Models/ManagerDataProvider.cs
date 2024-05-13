using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ПРОЕКТ2.Data;

namespace ПРОЕКТ2.Models
{
    public class Manager
    {

        public string WorkArea { get; set; }
        public string Name { get; set; }
        public string Achievement { get; set; }
    }
    public static class ManagerDataProvider
    {
        public static Dictionary<string, Dictionary<string, string>> GetManagerData()
        {
            // Создайте экземпляр вашего контекста базы данных
            var dbContext = new DB1Context();

            // Выполните запрос к таблице Managers и получите нужные данные
            var managerData = dbContext.Managers
                .ToDictionary(m => m.WorkArea,
                    m => new Dictionary<string, string>
                    {
                        { "Name", m.Name },
                        { "Achievement", m.Achievement }
                    });

            return managerData;
        }

    }
}
