using System;
using System.Collections.Generic;
using System.Text;

namespace BodyMassIndexCalculator.Models
{
    class Measurements
    {
        public double Height { get; set; }
        public double Weight { get; set; }
        public int HeightType { get; set; }
        public int WeightType { get; set; }

        private double MeasureHeight(double height, int heightType)
        {
            switch (heightType)
            {
                case 0:
                    height = height * 1; //Standart : meter
                    break;
                case 1:
                    height = height * Math.Pow(10, -2);
                    break;
                case 2:
                    height = height * Math.Pow(10, -3);
                    break;
                case 3:
                    height = height * (2.54);
                    break;
                case 4:
                    height = height * (30.48);
                    break;
                default:
                    return -1;
            }
            return height;

        }
        private double MeasureWeight(double weight, int weightType)
        {
            switch (weightType)
            {
                case 0:
                    weight = weight * 1; //Standart : Kilogram
                    break;
                case 1:
                    weight = weight * Math.Pow(10, -3);
                    break;
                case 2:
                    weight = weight * Math.Pow(10, -6);
                    break;
                case 3:
                    weight = weight * (0.45359237);
                    break;
                default:
                    return -1;
            }
            return weight;

        }

        public double MeasureBMI(double weight, double height , int weightType , int heightType)
        {
            height = MeasureHeight(height, heightType);
            weight = MeasureWeight(weight, weightType);
            double result = weight / (height * height);
            return result;
        }

        public string GetBMICategories(double bmi)
        {
            string category;
            if (bmi < 18.5) category = "Underweight";
            else if (bmi > 18.5 && bmi < 24.9) category = "Normal weight";
            else if (bmi > 25 && bmi < 29.9) category = "Over weight";
            else if (bmi > 30 && bmi < 39.9) category = "Obesity";
            else category = "Severe obesity";
            return category;
        }

    }


}
