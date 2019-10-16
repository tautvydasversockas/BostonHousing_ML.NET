using Microsoft.ML.Data;

namespace BostonHousing.ConsoleApp.Models
{
    public sealed class BostonHousePrediction
    {
        [ColumnName("Score")]
        public float Medv { get; set; }
    }
}