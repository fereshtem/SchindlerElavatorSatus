using System;
using System.Collections.Generic;
using System.Text;

namespace Schindler.ElavatorStatus.Domain
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
    }
}
