namespace Sparcpoint.Domain.SeedWork
{
    using System;

    public abstract class Entity
    {
        int? _requestedHashCode;
        public virtual int Id { get; protected set; }

        public bool IsTransient()
        {
            return this.Id == default(Int32);
        }

        public override bool Equals(object obj)
        {
            if (obj is null or not Entity)
                return false;

            if (Object.ReferenceEquals(this, obj))
                return true;

            if (this.GetType() != obj.GetType())
                return false;

            Entity item = (Entity)obj;

            if (item.IsTransient() || this.IsTransient())
                return false;
            return item.Id == this.Id;
        }

        public override int GetHashCode()
        {
            if (IsTransient()) return base.GetHashCode();

            if (!_requestedHashCode.HasValue)
                _requestedHashCode = this.Id.GetHashCode() ^ 31;

            return _requestedHashCode.Value;

        }
        public static bool operator ==(Entity left, Entity right)
        {
            if (Object.Equals(left, null))
                return (Object.Equals(right, null)) ? true : false;
            return left.Equals(right);
        }

        public static bool operator !=(Entity left, Entity right)
        {
            return !(left == right);
        }
    }
}
