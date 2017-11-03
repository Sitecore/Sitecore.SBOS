namespace Sitecore.Sbos.RelevantContentDetect.Data
{
    public interface IProfiledItemAssociation : IProfiledItemDistance
    {
        double Association { get; }
    }
}
