using AutoMapper;
using eFrizer.Database;
using eFrizer.Model;
using eFrizer.Services.Interfaces;
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
    }
}
