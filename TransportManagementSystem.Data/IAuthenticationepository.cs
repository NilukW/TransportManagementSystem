using System.Threading.Tasks;
using TransportManagementSystem.Model;
using TransportManagementSystem.Model.Auth;

namespace TransportManagementSystem.Data
{
    public interface IAuthenticationRepository : IGenericRepository<AuthenticateData>
    {
        Task<User> ValidateUser(string userName, string password);
    }
}