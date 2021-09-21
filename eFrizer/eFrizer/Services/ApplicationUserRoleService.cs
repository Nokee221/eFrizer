using AutoMapper;
using eFrizer.Database;
using eFrizer.Model;

namespace eFrizer.Services
{
    public class ApplicationUserRoleService : BaseCRUDService<Model.ApplicationUserRole, Database.ApplicationUserRole, object, ApplicationUserRoleInsertRequest, object>, ICRUDService<Model.ApplicationUserRole, object, ApplicationUserRoleInsertRequest, object>
    {
        public ApplicationUserRoleService(eFrizerContext context, IMapper mapper)
            : base(context, mapper)
        {

        }
    }
}
