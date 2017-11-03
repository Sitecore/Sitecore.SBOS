namespace Sitecore.Sbos.RelevantContentDetect.Data
{
    public class ProfiledItemWeight : ProfiledItemDistance, IProfiledItemWeight
    {
        public ProfiledItemWeight(double weight, IProfiledItemDistance distance)
            : base(distance.Distance, distance.Gravity)
        {
            Weight = weight;
        }
        public double Weight { get; protected set; }

        public override double GetResult() { return Weight; }

        public override string ToString()
        {
            return string.Format("{0:P2}", GetResult());
        }

    }
}
