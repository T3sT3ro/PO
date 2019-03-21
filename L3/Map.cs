public class Map<K, V>{

    private class Pair{
        public K key;
        public V val;

        public Pair(K key, V val){
            this.key = key;
            this.val = val;
        }
    }

    private List<Pair> dict = new List<Pair>();

    public V Get(K key){
        List<Pair>.Iterator it = dict.Head();
        while(!it.Value().key.Equals(key) && it.HasNext())
            it.Next();
        
        if(!(it.Value().key.Equals(key)))
            return default(V);
        else return it.Value().val;
    }

    public void Set(K key, V val){
        List<Pair>.Iterator it = dict.Head();
        while(!it.Value().key.Equals(key) && it.HasNext())
            it.Next();
        
        if(!(it.Value().key.Equals(key)))
            return;
        
        it.Value().val = val;
    }

    public void Remove(K key){
        List<Pair>.Iterator it = dict.Head();
        while(!it.Value().key.Equals(key) && it.HasNext())
            it.Next();
        
        if(!(it.Value().key.Equals(key)))
            return;
        
    }

} 