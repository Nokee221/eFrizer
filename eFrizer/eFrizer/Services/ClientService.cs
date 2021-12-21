using AutoMapper;
using eFrizer.Database;
using eFrizer.Model;
using eFrizer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFrizer.Services
{
    public class ClientService : BaseCRUDService<Model.Client, Database.Client, ClientSearchRequest, ClientInsertRequest, ClientUpdateRequest>, IClientService
    {
        public ClientService(eFrizerContext context, IMapper mapper)
           : base(context, mapper)
        {

        }

        class HairSalonRating
        {
            [KeyType]
            public float ClientId { get; set; }
            [KeyType]
            public float HairSalonId { get; set; }
            
            public float Label { get; set; }
        }

        class HairSalonRatingPrediction
        {
            public float Label { get; set; }
            public float Score { get; set; }
        }

        private static MLContext mlContext = null;
        private static ITransformer model = null;

        public List<Model.HairSalon> Recommend(int clientId)
        {
            if(mlContext == null)
            {
                mlContext = new MLContext();

                var tmpData = Context.Reviews.ToList();
                var data = new List<HairSalonRating>();

                foreach (var review in tmpData)
                {
                    data.Add(new HairSalonRating
                    {
                        ClientId = review.ClientId,
                        HairSalonId = review.HairSalonId,
                        Label = review.StarRating
                    });
                }

                var trainingData = mlContext.Data.LoadFromEnumerable(data);

                var options = new MatrixFactorizationTrainer.Options
                {
                    MatrixColumnIndexColumnName = "ClientId",
                    MatrixRowIndexColumnName = "HairSalonId",
                    LabelColumnName = "StarRating",
                    NumberOfIterations = 20,
                    ApproximationRank = 100,
                    LossFunction = MatrixFactorizationTrainer.LossFunctionType.SquareLossOneClass,
                    Alpha = 0.01,
                    Lambda = 0.025,
                    C = 0.000001
                };

                var est = mlContext.Recommendation().Trainers.MatrixFactorization(options);

                model = est.Fit(trainingData);
            }


            return null;
        }


    }
}
