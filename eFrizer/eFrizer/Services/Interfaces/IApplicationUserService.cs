using eFrizer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//TODO: should the interfaces for the services have their own namespace?
namespace eFrizer.Services
{
    public interface IApplicationUserService : ICRUDService<ApplicationUser, ApplicationUserSearchRequest, ApplicationUserInsertRequest, ApplicationUserUpdateRequest>
    {
        Task<Model.ApplicationUser> Login(string username, string password);
        Model.Manager RegisterManager(ManagerInsertRequest request);
        Model.Client RegisterClient(ClientInsertRequest request);
    }
}
