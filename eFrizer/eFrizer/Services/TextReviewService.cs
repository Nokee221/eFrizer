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
    public class TextReviewService : BaseCRUDService<Model.TextReview, Database.TextReview, TextReviewSearchRequest, TextReviewInsertRequest, object>, ITextReviewService
    {
        public TextReviewService(eFrizerContext context, IMapper mapper)
          : base(context, mapper)
        {
        }
    }
}
