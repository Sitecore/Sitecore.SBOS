using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace Sitecore.Sbos.RelatedContentDetection.UI
{
    public struct Templates
    {
        public struct RelatedContentDetectionItem
        {
            public static ID ID = new ID("{E471C4D6-99C8-4116-ABC8-BB3E4A1D9727}");

            public struct Fields    
            {
                public static ID Title = new ID("{2D34BC0A-25F3-4180-8BA7-B84C1CFA8325}");
                public static ID Summary = new ID("{974861A1-D8C6-4C32-AFEA-B3C2B18D78D4}");
                public static ID Link = new ID("{87253B14-ABCA-43AF-845A-831437B4681B}");
            }
        }
    }
}