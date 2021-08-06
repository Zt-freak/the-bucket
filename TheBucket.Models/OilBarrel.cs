namespace TheBucket.Models
{
    public class OilBarrel : Container
    {
        public OilBarrel() : this(0)
        {

        }

        public OilBarrel(double initialContents)
        {
            Capacity = 159;
            Contents = initialContents;
        }
    }
}
