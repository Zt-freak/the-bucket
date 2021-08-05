using System;

namespace TheBucket.Models
{
    public abstract class Container : IContainer
    {
        public double Capacity { get; }
        public double Contents { get; set; }

        public void Empty()
        {
            Contents = 0;
        }

        public void Fill(double addedVolume)
        {
            double overflow = GetOverflow(addedVolume);
            if (overflow > 0)
            {
                CapacityReachedEventArgs args = new CapacityReachedEventArgs();
                args.Overflow = overflow;
                OnCapacityReached(args);
            }
            else
            {
                Contents += addedVolume;
            }

            if (Contents > Capacity)
            {
                Contents = Capacity;
            }
        }

        public void Pour(double transferVolume, IContainer otherContainer, FillProtocol protocol)
        {
            double pouredVolume = 0;
            switch (protocol)
            {
                case FillProtocol.Cancel:
                    otherContainer.CapacityReached += (object sender, CapacityReachedEventArgs e) =>
                    {
                        pouredVolume = 0;
                    };
                    break;
                case FillProtocol.Fill:
                    otherContainer.CapacityReached += (object sender, CapacityReachedEventArgs e) =>
                    {
                        pouredVolume = transferVolume - e.Overflow;
                    };
                    break;
                case FillProtocol.Overflow:
                    otherContainer.CapacityReached += (object sender, CapacityReachedEventArgs e) =>
                    {
                        pouredVolume = transferVolume;
                    };
                    break;
            }
            otherContainer.Contents += pouredVolume;
            Contents -= pouredVolume;
        }

        public double GetOverflow(double addedVolume)
        {
            return Capacity - Contents - addedVolume;
        }

        protected virtual void OnCapacityReached(CapacityReachedEventArgs e)
        {
            CapacityReached?.Invoke(this, e);
        }

        public event EventHandler<CapacityReachedEventArgs> CapacityReached;
    }
}
