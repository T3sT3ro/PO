using System;
using System.Text;

public class RandomStream : IntStream {
    Random random;
    override public int next() { return random.Next(); }
    override public bool eos() { return false; }

    override public void reset() { random = new Random(); }
}