public class IntStream : Stream<int> {
    protected int val = 0;

    public IntStream() { reset(); }
    override public int next() { return this.val++; }
    override public bool eos() { return this.val == int.MaxValue; }
    override public void reset() { this.val = 0; }
}