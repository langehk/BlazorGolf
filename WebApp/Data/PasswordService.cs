using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Data
{
    public class PasswordService
    {
        public string genPassword()
        {
            return Guid.NewGuid().ToString("d").Substring(1, 12);
        }

    }
}
