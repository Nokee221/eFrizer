using eFrizer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Controllers
{
    public class BaseCRUDController<T, TSearch, TInsert, TUpdate> : BaseReadController<T, TSearch> where T : class where TSearch : class where TInsert : class where TUpdate : class
    {
        protected readonly ICRUDService<T, TSearch, TInsert, TUpdate> _crudService;
        public BaseCRUDController(ICRUDService<T, TSearch, TInsert, TUpdate> service) : base(service)
        {
            _crudService = service;
        }

        [AllowAnonymous]
        [HttpPost]
        public async virtual Task<T> Insert([FromBody] TInsert request)
        {
            return await _crudService.Insert(request);
        }

        [HttpPut("{id}")]
        public async virtual Task<T> Update(int id, [FromBody] TUpdate request)
        {
            return await _crudService.Update(id, request);
        }   
    }
}
