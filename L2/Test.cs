using System;

public class Program {
    static void Main(string[] args) {

        //---------------------
        Console.WriteLine("[Testing RandomWordStream]");
        RandomWordStream rws = new RandomWordStream();
        for (int i = 0; i < 10; i++)
            Console.WriteLine($" > {rws.next()} < ");

        //---------------------
        Console.WriteLine("[Testing LazyList]");
        LazyList LL = new LazyList();
        Console.WriteLine($"LL> size:{LL.size()}");
        Console.WriteLine($"LL> [0]: {LL.element(0)}\tsize:{LL.size()}");
        Console.WriteLine($"LL> [0]: {LL.element(0)}\tsize:{LL.size()}");
        Console.WriteLine($"LL> [40]:{LL.element(40)}\tsize:{LL.size()}");
        Console.WriteLine($"LL> [38]:{LL.element(38)}\tsize:{LL.size()}");
        Console.WriteLine($"LL> [50]:{LL.element(50)}\tsize:{LL.size()}");
        Console.WriteLine($"LL> [38]:{LL.element(38)}\tsize:{LL.size()}");

        //---------------------
        Console.WriteLine("[Testing PrimeLazyList]");
        LazyList PLL = new PrimeLazyList();
        Console.WriteLine($"PLL> size:{PLL.size()}");
        Console.WriteLine($"PLL> [0]: {PLL.element(0)}\tsize:{PLL.size()}");
        Console.WriteLine($"PLL> [0]: {PLL.element(0)}\tsize:{PLL.size()}");
        Console.WriteLine($"PLL> [40]:{PLL.element(40)}\tsize:{PLL.size()}");
        Console.WriteLine($"PLL> [38]:{PLL.element(38)}\tsize:{PLL.size()}");
        Console.WriteLine($"PLL> [50]:{PLL.element(50)}\tsize:{PLL.size()}");
        Console.WriteLine($"PLL> [38]:{PLL.element(38)}\tsize:{PLL.size()}");
    }
}