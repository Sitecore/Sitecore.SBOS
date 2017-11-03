using Sitecore.Analytics.Data;
using Sitecore.Data.Items;

namespace Sitecore.Sbos.RelevantContentDetect.Data
{
    public interface IProfiledItem
    {
        Item Item { get; }

        IProfiledItemCalculation ProfiledItemCalculation { get; }

        ContentProfile ContentProfile { get; }

        void SetContentProfile(ContentProfile contentProfile);

        void SetCalculation(IProfiledItemCalculation profiledItemProfile);
    }
}
