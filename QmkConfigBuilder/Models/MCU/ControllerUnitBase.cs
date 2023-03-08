using QmkConfigBuilder.Models.MCU.Definitions.Pinout;

namespace QmkConfigBuilder.Models.MCU
{
    public abstract class ControllerUnitBase : IControllerUnit
    {
        public abstract string Name { get; }

        public abstract string ReferenceUrl { get; }

        public IEnumerable<IPin> GetAllPins()
        {
            return this.GetLeftPins()
                .Concat(this.GetBottomPins())
                .Concat(this.GetRightPins())
                .Concat(this.GetTopPins());
        }

        public virtual IEnumerable<IPin> GetTopPins()
        {
            yield break;
        }

        public virtual IEnumerable<IPin> GetBottomPins()
        {
            yield break;
        }

        public virtual IEnumerable<IPin> GetLeftPins()
        {
            yield break;
        }

        public virtual IEnumerable<IPin> GetRightPins()
        {
            yield break;
        }

        public override bool Equals(object? obj)
        {
            return obj is IControllerUnit other
                && this.Name == other.Name;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
