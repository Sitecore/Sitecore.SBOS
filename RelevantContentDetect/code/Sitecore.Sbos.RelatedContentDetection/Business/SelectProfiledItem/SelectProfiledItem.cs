using Sitecore.Sbos.RelevantContentDetect.Business.CalculateItemProfile;
using Sitecore.Sbos.RelevantContentDetect.Data;

namespace Sitecore.Sbos.RelevantContentDetect.Business.SelectProfiledItem
{
    public abstract class SelectProfiledItem : ISelectProfiledItem
    {
        public SelectProfiledItem(ICalculateItemProfile calc)
        {
            CalculateItemProfile = calc;
        }

        public abstract IProfiledItemResult GetProfiledItem(IProfiledItemList list);

        public abstract string StringKey { get; }

        public ICalculateItemProfile CalculateItemProfile { get; private set; }

    }

    
}
