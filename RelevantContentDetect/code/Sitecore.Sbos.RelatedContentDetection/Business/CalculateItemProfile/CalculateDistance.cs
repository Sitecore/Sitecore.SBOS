using System;
using System.Collections.Generic;
using System.Linq;
using Sitecore.Analytics.Data.Items;
using Sitecore.Analytics.Patterns;
using Sitecore.Sbos.RelevantContentDetect.Data;

namespace Sitecore.Sbos.RelevantContentDetect.Business.CalculateItemProfile
{
    public class CalculateDistance : CalculateItemProfile, ICalculateDistance
    {
        public CalculateDistance()
        {
            calculator = new SquaredEuclidianDistance();
        }

        protected IPatternDistance calculator { get; set; }

        protected const double minDistance = 0.01d;
        protected const double defaultDistance = 10.0d; //double.PositiveInfinity


        public override void Calculate(Analytics.Tracking.Profile profile, IProfiledItemList list, string profileName, ProfileItem profileItem)
        {
            base.Calculate(profile, list, profileName, profileItem);

            var profiledList = list.Where(pi => pi.ContentProfile != null).ToList();

            PatternSpace space = profileItem.PatternSpace;

            var zeroSize = space.Dimensions;
            var zeroDouble = new double[zeroSize];
            for (int i = 0; i < space.Dimensions; i++)
            {
                zeroDouble[i] = 0.0d;
            }
            Pattern zeroPattern = new Pattern(space, zeroDouble);

            Pattern visitorPattern = zeroPattern;

            if (profile != null)
            {
                double[] numArray = new double[space.Dimensions];
                bool calcPercentage = (profileItem.Type.Equals("percentage", StringComparison.InvariantCultureIgnoreCase));
                if (profile.Count > 0 && calcPercentage)
                {
                    double percentageMultiplier = (calcPercentage) ? 100.0d : 1.0d;

                    float total = profile.Total;
                    foreach (KeyValuePair<string, float> keyValuePair in (IEnumerable<KeyValuePair<string, float>>)profile)
                    {
                        numArray[space.GetKeyIndex(keyValuePair.Key)] = ((double)keyValuePair.Value / (double)total) * percentageMultiplier;
                    }
                    var profileType = profileItem.Type;
                    visitorPattern = new Pattern(space, numArray);

                }
                else if (profile.Count > 0)
                {
                    //visitorPattern = space.CreatePattern(currentVisitorProfile.Values);

                    double percentageMultiplier = calcPercentage ? 100.0d : 1.0d;

                    float total = profile.Total;
                    int count = profile.Count;
                    foreach (KeyValuePair<string, float> keyValuePair in (IEnumerable<KeyValuePair<string, float>>)profile)
                    {
                        numArray[space.GetKeyIndex(keyValuePair.Key)] = ((double)keyValuePair.Value / count);
                    }
                    var profileType = profileItem.Type;
                    visitorPattern = new Pattern(space, numArray);
                }
            }
            
            profiledList.ForEach(item => CalculateProfiledItemDistance(calculator, item, profileName, profileItem, visitorPattern));
        }

        private static void CalculateProfiledItemDistance(IPatternDistance calculator, IProfiledItem item, string profileName, ProfileItem profileItem, Pattern visitorPattern)
        {
            PatternSpace space = profileItem.PatternSpace;
            Pattern itemPattern = space.CreatePattern(item.ContentProfile);

           
            double distance = defaultDistance;
            if (visitorPattern != null)
            {
                distance = Math.Sqrt(calculator.GetDistance(visitorPattern, itemPattern));
            }

            var correctedDistance = distance;

            if (correctedDistance < minDistance)
            {
                correctedDistance = minDistance;
            }

            double gravity = 1.0d / (correctedDistance * correctedDistance);

            // set the profiled item calculation property
            item.SetCalculation(new ProfiledItemDistance(distance, gravity));

            return;

        }
    }
}
