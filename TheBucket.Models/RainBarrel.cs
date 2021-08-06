﻿namespace TheBucket.Models
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
            if (capacity == 80 || capacity == 100 || capacity == 120)
            {
                
                _capacity = capacity;
            }
            else if (Capacity == 0)
            {
                _capacity = 80;
            }
            Contents = initialContents;
        }

    }
}
