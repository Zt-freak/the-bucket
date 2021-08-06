using System;

namespace TheBucket.Models.Interfaces
{
    public interface IContainer
    {
        double Capacity { get; set; }
        double Contents { get; set; }
        double GetOverflow(double addedVolume);
        void Fill(double addedVolume);
        void Pour(double transferVolume, IContainer otherContainer, FillProtocol protocol);
        void Empty();
        event EventHandler<CapacityReachedEventArgs> CapacityReached;
    }

    public enum FillProtocol
    {
        Overflow,
        Fill,
        Cancel
    }

    public class CapacityReachedEventArgs : EventArgs
    {
        public double Overflow { get; set; }
    }
}
