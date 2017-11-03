using Sitecore.Sbos.RelevantContentDetect.Data;

namespace Sitecore.Sbos.RelevantContentDetect.Business.SelectProfiledItem
{
    public interface ISelectFuzzyProfiledItem : ISelectProfiledItem
    {
        IProfiledItemResult GetFuzzyProfiledItem(IProfiledItemList list);
    }
}
