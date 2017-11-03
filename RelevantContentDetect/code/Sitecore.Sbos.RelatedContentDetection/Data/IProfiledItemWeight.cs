namespace Sitecore.Sbos.RelevantContentDetect.Data
{
    public interface IProfiledItemWeight : IProfiledItemDistance
    {
        double Weight { get; }
    }
}
