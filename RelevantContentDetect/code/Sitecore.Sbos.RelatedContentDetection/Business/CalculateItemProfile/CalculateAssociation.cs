using System;
using System.Collections.Generic;
using System.Linq;
using Sitecore.Analytics.Data.Items;
using Sitecore.Sbos.RelevantContentDetect.Data;

namespace Sitecore.Sbos.RelevantContentDetect.Business.CalculateItemProfile
{
    public class CalculateAssociation : CalculateDistance, ICalculateAssociation
    {
        public CalculateAssociation()
            : base()
        {
        }

        public override void Calculate(Analytics.Tracking.Profile profile, IProfiledItemList list, string profileName, ProfileItem profileItem)
        {
            base.Calculate(profile, list, profileName, profileItem);
            var profiledList = list.Where(pi => pi.ContentProfile != null).ToList();
            CalculateRelevantItemAssociation(profiledList);
        }

        private static double TVar = 1.00d;

        private static void CalculateRelevantItemAssociation(List<IProfiledItem> list)
        {
            list.ForEach(item => CalculateRelevantItemTempAssociation(item));
            double associationSum = list.Select(item => item.ProfiledItemCalculation as ProfiledItemAssociation).Sum(a => a.Association);
            list.ForEach(item => CalculateRelevantItemAssociation(item, associationSum));
        }

        private static void CalculateRelevantItemTempAssociation(IProfiledItem item)
        {
            var distance = item.ProfiledItemCalculation as IProfiledItemDistance;
            var association = Math.Exp( -distance.Distance / TVar);
            item.SetCalculation(new ProfiledItemAssociation(association, distance));
        }

        private static void CalculateRelevantItemAssociation(IProfiledItem item, double associationSum)
        {
            var association = item.ProfiledItemCalculation as IProfiledItemAssociation;
            var tempAssociation = association.Association;
            var newAssociation = (associationSum > 0d) ? tempAssociation / associationSum : 0d;
            item.SetCalculation(new ProfiledItemAssociation(newAssociation, association));
        }

    }
}
