namespace TheBucket.Models
{
    public class RainBarrel : Container
    {
        public RainBarrel() : this(RainBarrelVolume.Small, 0)
        {

        }

        public RainBarrel(RainBarrelVolume capacity) : this(capacity, 0)
        {

        }

        public RainBarrel(RainBarrelVolume capacity, double initialContents)
        {
            switch (capacity)
            {
                case RainBarrelVolume.Small:
                    Capacity = 80;
                    break;
                case RainBarrelVolume.Medium:
                    Capacity = 100;
                    break;
                case RainBarrelVolume.Large:
                    Capacity = 120;
                    break;
            }
            Contents = initialContents;
        }
    }

    public enum RainBarrelVolume
    {
        Small,
        Medium,
        Large
    }
}
