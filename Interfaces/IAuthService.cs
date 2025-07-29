using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceAPI.Interfaces
{
    public interface IAuthService
    {
        string GenerateToken(string username, string role);
    }
}