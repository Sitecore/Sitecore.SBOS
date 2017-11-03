namespace Sitecore.Sbos.RelevantContentDetect.Data
{
    public interface IProfiledItemDistance : IProfiledItemCalculation
    {
        double Distance { get; }
        double Gravity { get; }
    }
}
