using eFrizer.Model;
using eFrizer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Controllers
{

    public class ApplicationUserController : BaseCRUDController<Model.ApplicationUser, ApplicationUserSearchRequest, ApplicationUserInsertRequest, object>
    {
        private readonly IApplicationUserService service;
        public ApplicationUserController(IApplicationUserService service)
            : base(service)
        {
            this.service = service;
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public override Task<List<ApplicationUser>> Get([FromQuery] ApplicationUserSearchRequest search)
        {
           return base.Get(search);
        }

        [AllowAnonymous]     
        [HttpGet("/Login")]
        public async Task<ApplicationUser> Login([FromQuery]ApplicationUserLoginRequest request)
        {
            return await service.Login(request.Username, request.Password);
        }


        [AllowAnonymous]
        [HttpPost("/Register")]
        public async Task<Manager> Register([FromBody] ManagerInsertRequest request)
        {

            request.Roles.Add(service.GetRole("Manager").Id);

            return await service.RegisterManager(request);
        }



    }
}
