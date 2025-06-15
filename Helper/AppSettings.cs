using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
    public static class AppSettings
    {
        public static int VangLaiCustomerId { get; }

        static AppSettings()
        {

            if (!int.TryParse(ConfigurationManager.AppSettings["VangLaiCustomerId"], out int customerId))
            {
                throw new ConfigurationErrorsException("Key 'VangLaiCustomerId' không tìm thấy hoặc không phải là một số nguyên hợp lệ trong App.config.");
            }
            VangLaiCustomerId = customerId;
        }
    }
}
