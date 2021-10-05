using AutoMapper;
using eFrizer.Database;
using eFrizer.Filters;
using eFrizer.Helpers;
using eFrizer.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace eFrizer.Services
{
    public class ApplicationUserService : BaseCRUDService<Model.ApplicationUser, Database.ApplicationUser, ApplicationUserSearchRequest, ApplicationUserInsertRequest, object>, IApplicationUserService
    {
        public ApplicationUserService(eFrizerContext context, IMapper mapper)
            : base(context, mapper)
        {

        }

        public async override Task<List<Model.ApplicationUser>> Get([FromBody] ApplicationUserSearchRequest search = null)
        {
            var entity = Context.Set<Database.ApplicationUser>().AsQueryable();

            if (search?.IncludeList?.Length > 0)
            {
                foreach (var item in search.IncludeList)
                {
                    if(item == "ApplicationUserRoles")
                    {
                        entity = entity.Include(x => x.ApplicationUserRoles).ThenInclude(x => x.Role);
                        continue;
                    }

                    entity.Include(item);
                }
            }

            var list = await entity.ToListAsync();

            return _mapper.Map<List<Model.ApplicationUser>>(list);
        }

        public async override Task<Model.ApplicationUser> Insert(ApplicationUserInsertRequest request)
        {
            //TODO: Check if username already exists!
            var entity = _mapper.Map<Database.ApplicationUser>(request);
            Context.Add(entity);

            if (request.Password != request.PasswordConfirmation)
            {
                throw new UserException("Passwordi se ne podudaraju!");
            }

            entity.PasswordSalt = AuthHelper.GenerateSalt();
            entity.PasswordHash = AuthHelper.GenerateHash(entity.PasswordSalt, request.Password);

            await Context.SaveChangesAsync();

            foreach (var uloga in request.Roles)
            {
                Database.ApplicationUserRole appUserRole = new Database.ApplicationUserRole();
                appUserRole.ApplicationUserId = entity.ApplicationUserId;
                appUserRole.RoleId = uloga;
                //TODO: add ChangeDate prop to model
                //appUserRole.ChangeDate = DateTime.Now;

                Context.ApplicationUserRoles.Add(appUserRole);
            }

            //Context.SaveChanges();

            return _mapper.Map<Model.ApplicationUser>(entity);
        }

        public async Task<Model.ApplicationUser> Login(string username, string password)
        {
            var entity = await Context.ApplicationUsers
                .Include(x => x.ApplicationUserRoles).ThenInclude(x => x.Role)
                .FirstOrDefaultAsync(x => x.Username == username);

            if (entity == null)
            {
                throw new UserException("Pogrešan username ili password");
            }

            var hash = AuthHelper.GenerateHash(entity.PasswordSalt, password);

            if (hash != entity.PasswordHash)
            {
                throw new UserException("Pogrešan username ili password");
            }

            return _mapper.Map<Model.ApplicationUser>(entity);
        }
    }
}
