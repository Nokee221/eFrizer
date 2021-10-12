using eFrizer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class BaseReadController<T, TSearch> : ControllerBase where T : class where TSearch : class
    {
        protected readonly IReadService<T, TSearch> _service;

        public BaseReadController(IReadService<T, TSearch> service)
        {
            _service = service;
        }


        [HttpGet]
        public async virtual Task<List<T>> Get([FromQuery] TSearch search)
        {
            return await _service.Get(search);
        }

        
        [HttpGet("{id}")]
        public async virtual Task<T> GetById(int id)
        {
            return await _service.GetById(id);
        }
    }
}

