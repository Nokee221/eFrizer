using AutoMapper;
using eFrizer.Database;

namespace eFrizer.Services
{
    public class ApplicationUserRoleService : BaseCRUDService<Model.ApplicationUserRole, Database.ApplicationUserRole, object, object, object>, ICRUDService<Model.ApplicationUserRole, object, object, object>
    {
        public ApplicationUserRoleService(eFrizerContext context, IMapper mapper)
            : base(context, mapper)
        {

        }
    }
}
