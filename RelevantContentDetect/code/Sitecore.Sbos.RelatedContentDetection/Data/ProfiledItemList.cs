using System.Collections.Generic;
using System.Linq;
using Sitecore.Data.Items;

namespace Sitecore.Sbos.RelevantContentDetect.Data
{
    public class ProfiledItemList : List<IProfiledItem>, IProfiledItemList
    {
        public ProfiledItemList(IList<Item> items)
            : base(items.Select(i => new ProfiledItem(i)))
        {
        }
    }

}
