using System;
using System.IO;
using System.Linq;
using BostonHousing.ConsoleApp.Models;
using Microsoft.ML;

namespace BostonHousing.ConsoleApp
{
    class Program
    {
        public static void Main()
        {
            var dataPath = $"{Environment.CurrentDirectory}/Data/Boston.csv";
            var modelPath = "C:/Models/BostonModel.zip";

            var mlContext = new MLContext(seed: 0);

            var data = mlContext.Data.LoadFromTextFile<BostonHouse>(
                path: dataPath,
                hasHeader: true,
                separatorChar: ',');

            var trainer = mlContext.Regression.Trainers.LightGbm(numberOfIterations: 80);

            var pipeline = mlContext.Transforms
                .Concatenate(outputColumnName: "Features",
                    nameof(BostonHouse.PTRatio),
                    nameof(BostonHouse.Rm),
                    nameof(BostonHouse.Lstat))
                .Append(trainer);

            var crossValidationResults = mlContext.Regression.CrossValidate(
                data: data,
                estimator: pipeline,
                numberOfFolds: 4);

            Console.WriteLine($"Average RSquared: {crossValidationResults.Average(x => x.Metrics.RSquared)}");
            Console.WriteLine($"Average Mean Absolute Error: {crossValidationResults.Average(x => x.Metrics.MeanAbsoluteError)}");

            var model = pipeline.Fit(data);

            using (var fileStream = new FileStream(modelPath, FileMode.Create))
                mlContext.Model.Save(model, data.Schema, fileStream);

            Console.WriteLine("Model saved");
        }
    }
}