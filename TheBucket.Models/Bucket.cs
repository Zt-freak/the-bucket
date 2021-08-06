namespace TheBucket.Models
{
    public class Bucket : Container
    {
        public new readonly double Capacity;
        public Bucket() : this(12, 0)
        {

        }

        public Bucket(double capacity) : this(capacity, 0)
        {

        }

        public Bucket(double capacity, double initialContents)
        {
            if (capacity < 10)
            {
                _capacity = 10;
            }
            else
            {
                _capacity = capacity;
            }
            
            Contents = initialContents;
        }

    }
}
