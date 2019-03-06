public class PrimeLazyList : LazyList {

    PrimeStream ps = new PrimeStream();
    protected override int extend(int newSize){
        int elem=0;
        for (int i = 0, lim = newSize - base.L.Count; i < lim; i++)
            L.Add(elem = ps.next());
        return elem;
    }
}