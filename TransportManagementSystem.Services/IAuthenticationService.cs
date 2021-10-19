using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TransportManagementSystem.Model;

namespace TransportManagementSystem.Services
{
    public interface IAuthenticationService
    {
        Task<User> ValidateUser(string username, string password);
    }
}
