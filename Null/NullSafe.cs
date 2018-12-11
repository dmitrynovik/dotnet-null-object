namespace Null
{
    public class NullSafe<T> where T : class, new()
    {
        private T _value;

        public NullSafe()
        {
            _value = new T();
            IsNull = true;
        }

        public NullSafe(T value)
        {
            _value = value;
            IsNull = false;
        }

        public bool IsNull { get; private set; }

        public T Value
        {
            get => _value;
            set
            {
                IsNull = value == null;
                _value = value ?? new T();
            }
        }

        public static implicit operator T(NullSafe<T> arg) => arg.Value;

        public static implicit operator NullSafe<T>(T arg) => new NullSafe<T>(arg);

        public static bool operator ==(NullSafe<T> a, NullSafe<T> b)
        {
            if (ReferenceEquals(a, null))
                return ReferenceEquals(b, null) || b.IsNull;
            if (ReferenceEquals(b, null))
                return a.IsNull;

            return ReferenceEquals(a, b);
        }

        public static bool operator !=(NullSafe<T> a, NullSafe<T> b) => !(a == b);
    }

}
