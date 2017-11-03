using Sitecore.Sbos.RelevantContentDetect.Data;

namespace Sitecore.Sbos.RelevantContentDetect.Business.SelectProfiledItem
{
    public interface IProfiledItemResult
    {
        IProfiledItem ProfiledItem { get; }
        string Message { get; }
    }
}
