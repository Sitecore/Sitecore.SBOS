namespace Sitecore.Sbos.RelevantContentDetect.Data
{
    public class ProfiledItemAssociation : ProfiledItemDistance, IProfiledItemAssociation
    {
        public ProfiledItemAssociation(double association, IProfiledItemDistance distance) 
            : base(distance.Distance,distance.Gravity)
        {
            Association = association;
        }

        public double Association { get; protected set; }

        public override double GetResult() { return Association; }

        public override string ToString()
        {
            return string.Format("{0:P2}", GetResult());
        }

    }
}
