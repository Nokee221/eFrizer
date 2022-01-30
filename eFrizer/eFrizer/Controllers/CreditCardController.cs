using eFrizer.Model;
using eFrizer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Controllers
{

    public class CreditCardController : BaseCRUDController<Model.CreditCard, CreditCardSearchRequest, CreditCardInsertRequest, object>
    {

        public CreditCardController(ICreditCardService service) : base(service)
        {
        }
    }

}

