using System;
using Sitecore.Sbos.RelevantContentDetect.Data;

namespace Sitecore.Sbos.RelevantContentDetect.Business.SelectProfiledItem
{
    public class ProfiledItemResult : Tuple<IProfiledItem, String>, IProfiledItemResult
    {
        public ProfiledItemResult(IProfiledItem item1, String item2)
            : base(item1, item2)
        {
        }

        public IProfiledItem ProfiledItem { get { return Item1; } }
        public string Message { get { return Item2; } }
    }

}
