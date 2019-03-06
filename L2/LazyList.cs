using System;
using System.Collections.Generic;

public class LazyList {
    protected List<int> L = new List<int>();
    private static Random random = new Random();

    protected virtual int extend(int newSize) { // extends list to new size, returns last element
        int elem = 0;
        for (int i = 0, lim = newSize - L.Count; i < lim; i++)
            L.Add(elem = random.Next());
        return elem;
    } // normally I would implement in favor of some generator of Iterable interface,
    // but Random doesn't implement any such Interface...

    public int element(int idx) {
        if (idx < 0) return 0; // invalid case
        else if (idx < L.Count) return L[idx];
        else return extend(idx + 1);
    }

    public int size() => L.Count;
}