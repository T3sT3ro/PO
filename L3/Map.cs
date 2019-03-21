public class Map<K, V>
{

    private class Pair
    {
        public K key;
        public V val;

        public Pair(K key, V val)
        {
            this.key = key;
            this.val = val;
        }
    }

    private List<Pair> dict = new List<Pair>();

    /// Returns default of the type if key is not found
    private List<Pair>.Iterator Seek(K key)
    {
        List<Pair>.Iterator it = dict.Head();

        while (it.IsValid() && !it.At().key.Equals(key))
            it.Next();
        return it;
    }

    public V Get(K key)
    {
        List<Pair>.Iterator it = Seek(key);

        if (it.IsValid())
            return it.At().val;
        else
            return default(V);

    }

    public void Set(K key, V val)
    {
        List<Pair>.Iterator it = Seek(key);

        if (it.IsValid())
            it.At().val = val;
        else
            dict.PushBack(new Pair(key, val));
    }

    public void Remove(K key)
    {
        List<Pair>.Iterator it = Seek(key);

        if (it.IsValid() && it.At().key.Equals(key))
            dict.Remove(it);
    }

    public bool HasKey(K key) => Seek(key).IsValid();

}