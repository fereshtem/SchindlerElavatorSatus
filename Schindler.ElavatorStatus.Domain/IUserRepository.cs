using System;
using System.Collections.Generic;
using System.Text;

namespace Schindler.ElavatorStatus.Domain
{
    public interface IUserRepository
    {
        User Authenticate(string username, string password);
    }
}
