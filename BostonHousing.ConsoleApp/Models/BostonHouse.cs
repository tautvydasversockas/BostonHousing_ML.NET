using Microsoft.ML.Data;

namespace BostonHousing.ConsoleApp.Models
{
    public sealed class BostonHouse
    {
        //Per capita crime rate by town
        [LoadColumn(0)]
        public float Crim { get; set; }

        //Proportion of residential land zoned for lots over 25,000 sq.ft
        [LoadColumn(1)]
        public float Zn { get; set; }

        //Proportion of non-retail business acres per town
        [LoadColumn(2)]
        public float Indus { get; set; }

        //Charles River dummy variable(= 1 if tract bounds river{ get; set;} 0 otherwise)
        [LoadColumn(3)]
        public float Chas { get; set; }

        //Nitric oxide concentration(parts per 10 million)
        [LoadColumn(4)]
        public float Nox { get; set; }

        //Average number of rooms per dwelling
        [LoadColumn(5)]
        public float Rm { get; set; }

        //Proportion of owner-occupied units built prior to 1940
        [LoadColumn(6)]
        public float Age { get; set; }

        //Weighted distances to five Boston employment centers
        [LoadColumn(7)]
        public float Dis { get; set; }

        //Index of accessibility to radial highways
        [LoadColumn(8)]
        public float Rad { get; set; }

        //Full-value property tax rate per $10,000
        [LoadColumn(9)]
        public float Tax { get; set; }

        //Pupil-teacher ratio by town
        [LoadColumn(10)]
        public float PTRatio { get; set; }

        //1000(Bk — 0.63)², where Bk is the proportion of[people of African American descent] by town
        [LoadColumn(11)]
        public float B { get; set; }

        //Percentage of lower status of the population
        [LoadColumn(12)]
        public float Lstat { get; set; }

        //Median value of owner-occupied homes in $1000s
        [LoadColumn(13)]
        [ColumnName("Label")]
        public float Medv { get; set; }
    }
}