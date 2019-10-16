using System.IO;
using BostonHousing.ConsoleApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ML;

namespace BostonHousing.Web.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PredictionsController : ControllerBase
    {
        [HttpPost]
        public IActionResult Predict([FromBody]BostonHouse bostonHouse)
        {
            var mlContext = new MLContext(seed: 0);
            var modelPath = "C:/Models/BostonModel.zip";

            ITransformer model;
            using (var fileStream = new FileStream(modelPath, FileMode.Open))
                model = mlContext.Model.Load(fileStream, out _);

            var predictionEngine = mlContext.Model.CreatePredictionEngine<BostonHouse, BostonHousePrediction>(model);
            var prediction = predictionEngine.Predict(bostonHouse);

            return Ok($"Prediction result: {prediction.Medv:#.##}. Difference: {prediction.Medv - bostonHouse.Medv:#.##}");
        }
    }
}

//{
//"crim": 0.85204,
//"zn": 0,
//"indus": 8.14,
//"chas": 0,
//"nox": 0.538,
//"rm": 5.965,
//"age": 89.2,
//"dis": 4.0123,
//"rad": 4,
//"tax": 307,
//"ptRatio": 21,
//"b": 392.53,
//"lstat": 13.83,
//"medv": 15.48
//}