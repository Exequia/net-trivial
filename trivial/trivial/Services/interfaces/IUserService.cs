using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using trivial.Models;

namespace trivial.Services.interfaces
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
    }
}
