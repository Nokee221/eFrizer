using AutoMapper;
using eFrizer.Database;
using eFrizer.Model;
using eFrizer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Services
{
    public class CreditCardService : BaseCRUDService<Model.CreditCard, Database.CreditCard, CreditCardSearchRequest, CreditCardInsertRequest, object>, ICreditCardService
    {
        public CreditCardService(eFrizerContext context, IMapper mapper)
          : base(context, mapper)
        {
        }

        public async Task<List<Model.CreditCard>> Get([FromBody] CreditCardSearchRequest search = null)
        {
            if (search.ClientId != 0)
            {
                var list = await Context.CreditCards.Where(x => x.ClientId == search.ClientId).ToListAsync();
                return _mapper.Map<List<Model.CreditCard>>(list);
            }
            else
            {

                var list = await Context.CreditCards.ToListAsync();
                return _mapper.Map<List<Model.CreditCard>>(list);
            }

        }
    }
}
