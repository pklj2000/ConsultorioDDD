using System;
using System.Collections.Generic;
using System.Text;

namespace Consultorio.Service.Infrastructure
{
    interface ILoginService
    {
        bool ValidatePassword(string usuario, string password);
    }
}
