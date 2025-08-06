using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalApp
{
    public static class CalorieCalculator
    {
        public static double GetCaloriesBurned(
        int age, double height, double weight, string gender,
        string activity, double speed, string measureType,
        int steps, double distanceKm)
        {
            double finalDistanceKm = 0;

            if (measureType == "steps")
            {
                double stepLength = height * 0.415 / 100; // meters
                finalDistanceKm = (steps * stepLength) / 1000; // km
            }
            else
            {
                finalDistanceKm = distanceKm;
            }

            double durationHours = finalDistanceKm / speed;
            double met = GetMET(activity, speed);

            // Mifflin-St Jeor BMR calculation
            double bmr;
            if (gender.ToLower().StartsWith("m"))
            {
                bmr = 10 * weight + 6.25 * height - 5 * age + 5;
            }
            else
            {
                bmr = 10 * weight + 6.25 * height - 5 * age - 161;
            }

            return (bmr / 24) * met * durationHours;
        }

        private static double GetMET(string activity, double speed)
        {
            if (activity.ToLower() == "walking")
            {
                if (speed <= 3.2) return 2.8;
                if (speed <= 4.0) return 3.0;
                if (speed <= 4.5) return 3.3;
                if (speed <= 4.8) return 3.5;
                if (speed <= 5.6) return 4.3;
                if (speed <= 6.4) return 5.0;
                return 5.3;
            }
            else if (activity.ToLower() == "running")
            {
                if (speed <= 8.0) return 8.3;
                if (speed <= 9.6) return 9.8;
                if (speed <= 10.8) return 10.5;
                return 11.0;
            }

            return 1.0;
        }
    }
}
