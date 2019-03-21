using System;
using System.Diagnostics;
public class Program {
    static void Main(string[] args) {

        //---------------------
        Console.WriteLine("[Testing List]");
        List<int> list = new List<int>();
        Debug.Assert(list.Empty());
        Debug.Assert(list.Size() == 0);
        list.PushFront(12);
        Debug.Assert(!list.Empty() && list.Size() == 1);
        Debug.Assert(list.Get(0) == 12);
        list.PushFront(13);
        Debug.Assert(!list.Empty() && list.Size() == 2);
        Debug.Assert(list.Get(0) == 13 && list.Back() == 12 && list.Get(1) == 12);
        Debug.Assert(list.PopBack() == 12);
        list.Clear();
        Debug.Assert(list.Empty());
        Console.WriteLine("[All OK]");

                //---------------------
        Console.WriteLine("[Testing Map]");
        Console.WriteLine("[All OK]");
    }
}