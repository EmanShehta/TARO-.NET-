using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taro.Repository.Services
{
    public interface IEmailSettings
    {
        public void SendEmail(Mail email);
    }
}
