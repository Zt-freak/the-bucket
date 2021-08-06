namespace TheBucket.Models
{
    public class RainBarrel : Container
    {
        public RainBarrel() : this(80, 0)
        {

        }

        public RainBarrel(double capacity) : this(capacity, 0)
        {

        }

        public RainBarrel(double capacity, double initialContents)
        {
            Capacity = capacity;
            Contents = initialContents;
        }

        public override double Capacity
        {
            get => _capacity;
            set
            {
                if (Capacity == 0 && (value == 80 || value == 100 || value == 120))
                {
                    _capacity = value;
                }
                else if (Capacity == 0)
                {
                    _capacity = 80;
                }
            }
        }
    }
}
