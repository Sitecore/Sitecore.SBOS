using Sitecore.Sbos.RelevantContentDetect.Business.CalculateItemProfile;
using Sitecore.Sbos.RelevantContentDetect.Data;

namespace Sitecore.Sbos.RelevantContentDetect.Business.SelectProfiledItem
{
    

    public abstract class SelectFuzzyProfiledItem: SelectProfiledItem, ISelectFuzzyProfiledItem
    {
        public SelectFuzzyProfiledItem(ICalculateItemProfile calc) : base(calc)
        {
        }

        public abstract IProfiledItemResult GetFuzzyProfiledItem(IProfiledItemList list);
    }
}
