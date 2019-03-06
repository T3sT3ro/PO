public class PrimeStream : IntStream {
    // due to prime gap on [0..2^32] being less or equal than 54, check all divisors to sqrt
    // undefined behaviour after eos() returns true
    override public int next() {
        if (val == 0) {
            base.val = 2;
        } else if (val == 2) {
            base.val = 3;
        } else {
            bool isPrime = false;
            for (int p = base.val + 2; !isPrime && p <= int.MaxValue && p > 0; p += 2) {
                isPrime = true;
                for (int i = 3; isPrime && i * i <= p && i * i > 0; i++) // check all divisors to sqrt
                    isPrime = (p % i != 0); // if i| p => p is not prime

                if (isPrime) {
                    base.val = p;
                    break;
                }
            }
        }
        return base.val;
    }
    override public bool eos() { return base.val == int.MaxValue; }
    override public void reset() { base.val = 0; }
}