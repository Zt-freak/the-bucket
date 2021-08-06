namespace TheBucket.Models
{
    public class Bucket : Container
    {
        public Bucket() : this(12, 0)
        {

        }

        public Bucket(double capacity) : this(capacity, 0)
        {

        }

        public Bucket(double capacity, double initialContents)
        {
            Capacity = capacity;
            Contents = initialContents;
        }

        public override double Capacity
        {
            get => _capacity;
            set
            {
                if (_capacity == 0)
                {
                    _capacity = value;
                    if (value < 10)
                    {
                        _capacity = 10;
                    }
                }
            }
        }
    }
}
