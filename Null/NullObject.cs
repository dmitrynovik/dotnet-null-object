using System.ComponentModel;

namespace Null
{
    public abstract class NullObject : INotifyPropertyChanged
    {
        public bool IsDirty { get; private set; }

        public bool IsPristine => !IsDirty;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(PropertyChangedEventArgs eventArgs)
        {
            IsDirty = true;
            PropertyChanged?.Invoke(this, eventArgs);
        }

        public static bool operator ==(NullObject a, NullObject b)
        {
            if (ReferenceEquals(a, null))
                return ReferenceEquals(b, null) || b.IsPristine;
            if (ReferenceEquals(b, null))
                return a.IsPristine;

            return ReferenceEquals(a, b);
        }

        public static bool operator !=(NullObject a, NullObject b) => !(a == b);
    }
}
