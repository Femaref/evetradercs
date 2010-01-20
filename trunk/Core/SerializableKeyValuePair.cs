using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    [Serializable]
    public class SerializableKeyValuePair<TKey, TValue> : IComparable<SerializableKeyValuePair<TKey, TValue>> where TKey : IComparable<TKey>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }

        public SerializableKeyValuePair()
        {
        }

        public SerializableKeyValuePair(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }

        #region IComparable<SerializableKeyValuePair<TKey,TValue>> Members

        public int CompareTo(SerializableKeyValuePair<TKey, TValue> other)
        {
            return Key.CompareTo(other.Key);
        }

        #endregion

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append('[');
            if (this.Key != null)
            {
                sb.Append(this.Key.ToString());
            }
            sb.Append(", ");
            if (this.Value != null)
            {
                sb.Append(this.Value.ToString());
            }
            sb.Append(']');
            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            SerializableKeyValuePair<TKey, TValue> cast = (obj as SerializableKeyValuePair<TKey, TValue>);
            if (obj != null)
            {
                return (this.Key.Equals(cast.Key) && this.Value.Equals(cast.Value));
            }
            else
                return false;
        }
        public override int GetHashCode()
        {
            return this.Key.GetHashCode();
        }

        public static implicit operator KeyValuePair<TKey, TValue> (SerializableKeyValuePair<TKey, TValue> input)
        {
            return new KeyValuePair<TKey, TValue>(input.Key, input.Value);
        }
        public static implicit operator SerializableKeyValuePair<TKey, TValue>(KeyValuePair<TKey, TValue> input)
        {
            return new SerializableKeyValuePair<TKey, TValue>(input.Key, input.Value);
        }
    }
}
