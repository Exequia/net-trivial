using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using trivial.Models;

namespace trivial.Services.Interfaces
{
    public interface IUserService
    {
        UserModel Authenticate(UserModel user);
    }
}
