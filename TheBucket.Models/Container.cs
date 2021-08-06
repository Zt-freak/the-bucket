﻿using System;
using TheBucket.Models.Interfaces;

namespace TheBucket.Models
{
    public abstract class Container : IContainer
    {
        protected double _capacity = 0;
        public virtual double Capacity
        {
            get => _capacity;
            set {
                if (Capacity == 0)
                {
                    _capacity = value;
                }
            }
        }
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
                CapacityReachedEventArgs args = new()
                {
                    Overflow = overflow
                };
                OnCapacityReached(args);
            }
            else if(addedVolume < 0)
            {
                return;
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
            otherContainer.Fill(pouredVolume);
            Contents -= pouredVolume;
        }

        public double GetOverflow(double addedVolume)
        {
            return addedVolume - Capacity - Contents;
        }

        protected virtual void OnCapacityReached(CapacityReachedEventArgs e)
        {
            CapacityReached?.Invoke(this, e);
        }

        public event EventHandler<CapacityReachedEventArgs> CapacityReached;
    }
}
