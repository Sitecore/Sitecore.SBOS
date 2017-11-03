namespace Sitecore.Sbos.RelevantContentDetect.Data
{
    public class ProfiledItemDistance : IProfiledItemDistance
    {
        public ProfiledItemDistance(double distance, double gravity)
        {
            Distance = distance;
            Gravity = gravity;
        }
        public double Distance { get; protected set; }
        public double Gravity { get; protected set; }

        public virtual double GetResult() { return Distance; }

        public override string ToString()
        {
            return string.Format("{0:N2}", GetResult());
        }

    }
}
