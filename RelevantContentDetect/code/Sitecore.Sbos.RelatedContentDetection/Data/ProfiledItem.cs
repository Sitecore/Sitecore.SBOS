using Sitecore.Analytics.Data;
using Sitecore.Data.Items;

namespace Sitecore.Sbos.RelevantContentDetect.Data
{
    public class ProfiledItem : IProfiledItem
    {
        public ProfiledItem(Item item)
        {
            Item = item;
            ProfiledItemCalculation = null;
        }

        public Item Item { get; protected set; }
        public IProfiledItemCalculation ProfiledItemCalculation { get; protected set; }


        public ContentProfile ContentProfile { get; protected set; }

        public void SetContentProfile(ContentProfile contentProfile)
        {
            ContentProfile = contentProfile;
        }

        public void SetCalculation(IProfiledItemCalculation profiledItemProfile)
        {
            ProfiledItemCalculation = profiledItemProfile;
        }
    }
}
