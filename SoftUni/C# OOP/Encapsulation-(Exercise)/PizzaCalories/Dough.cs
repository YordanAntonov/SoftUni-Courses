using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {

        private const int calPerGram = 2;
        private const int minDoughGrams = 1;
        private const int maxDoughGrams = 200;

        private string flourType;

        private string bakingTechnique;

        private int doughGrams;

        private Dictionary<string, double> modifiers = new Dictionary<string, double>()
        {
            {"white", 1.5 },
            {"wholegrain", 1.0 },
            {"crispy", 0.9 },
            {"chewy", 1.1 },
            {"homemade", 1.0 }
        };

        public Dough(string flourType, string bakingTechnique, int doughGrams)
        {
            FlourType = flourType;

            BakingTechnique = bakingTechnique;

            DoughGrams = doughGrams;
        }

        public string FlourType
        {
            get { return flourType; }

            private set
            {
                string lowerValue = value.ToLower();
                if (lowerValue != "white" && lowerValue != "wholegrain")
                {
                    throw new Exception(string.Format(ExceptionMessages.INVALID_DOUGH_OR_TECHNIQUE));
                }

                flourType = value;
            }
        }

        public string BakingTechnique
        {
            get { return bakingTechnique; }

            private set
            {

                string lowerValue = value.ToLower();
                if (lowerValue != "crispy" && lowerValue != "chewy" && lowerValue != "homemade")
                {
                    throw new Exception(string.Format(ExceptionMessages.INVALID_DOUGH_OR_TECHNIQUE));
                }

                bakingTechnique = value;
            }
        }

        public int DoughGrams
        {
            get { return doughGrams; }

            private set
            {
                if (value < minDoughGrams || value > maxDoughGrams)
                {
                    throw new Exception(string.Format(ExceptionMessages.INVALID_DOUGH_WEIGHT));
                }

                doughGrams = value;
            }
        }

        public double GetDoughCalories()
        {
            double result = (calPerGram * DoughGrams) * modifiers[FlourType.ToLower()] * modifiers[BakingTechnique.ToLower()];

            return result;
        }

    }
}
