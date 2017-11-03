using Sitecore.Sbos.RelevantContentDetect.Business.CalculateItemProfile;
using Sitecore.Sbos.RelevantContentDetect.Data;

namespace Sitecore.Sbos.RelevantContentDetect.Business.SelectProfiledItem
{
    public interface ISelectProfiledItem
    {
        string StringKey { get; }

        ICalculateItemProfile CalculateItemProfile { get; }

        IProfiledItemResult GetProfiledItem(IProfiledItemList list);


    }

}
