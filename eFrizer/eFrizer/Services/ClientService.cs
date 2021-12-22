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
            [KeyType(count: 300)]
            public uint ClientId { get; set; }
            [KeyType(count: 300)]
            public uint HairSalonId { get; set; }    
            
            public float StarRating { get; set; }
        }

        class HairSalonRatingPrediction
        {
            public float Label { get; set; }
            public float Score { get; set; }
        }

        private static MLContext mlContext = null;
        private static ITransformer model = null;

        public async Task<List<Model.HairSalon>> Recommend(int clientId)
        {
            if(true)
            {
                mlContext = new MLContext();
                
                var tmpData = await Context.Reviews.ToListAsync();
                var data = new List<HairSalonRating>();

                foreach (var review in tmpData)
                {
                    data.Add(new HairSalonRating
                    {
                        ClientId = (uint)review.ClientId,
                        HairSalonId = (uint)review.HairSalonId,
                        StarRating = review.StarRating
                    });
                }

                var trainingData = mlContext.Data.LoadFromEnumerable(data);

                var options = new MatrixFactorizationTrainer.Options
                {
                    MatrixColumnIndexColumnName = "ClientId",
                    MatrixRowIndexColumnName = "HairSalonId",
                    LabelColumnName = "StarRating",
                    NumberOfIterations = 20,
                    ApproximationRank = 100
                };

                var est = mlContext.Recommendation().Trainers.MatrixFactorization(options);

                model = est.Fit(trainingData);
            }

            var hairSalons = await Context.HairSalons.ToListAsync();
            var predictionResult = new List<Tuple<Database.HairSalon, float>>();

            foreach (var salon in hairSalons)
            {
                var predictionEngine = mlContext.Model.CreatePredictionEngine<HairSalonRating, HairSalonRatingPrediction>(model);

                var prediction = predictionEngine.Predict(new HairSalonRating
                {
                    HairSalonId = (uint)salon.HairSalonId,
                    ClientId = (uint)clientId
                });

                predictionResult.Add(new Tuple<Database.HairSalon, float>(salon, prediction.Score));
            }

            var finalResult = predictionResult.OrderByDescending(x => x.Item2)
                .Select(x => x.Item1).Take(3).ToList();

            return _mapper.Map<List<Model.HairSalon>>(finalResult);
        }


    }
}
