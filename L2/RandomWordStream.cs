using System;
using System.Text;
public class RandomWordStream : Stream<string> {
    PrimeStream primeStream;
    RandomStream randomStream;
    public RandomWordStream() {
        primeStream = new PrimeStream();
        randomStream = new RandomStream();
    }

    override public string next() {
        const string chars = "``1234567890-=\\qwertyuiop[]asdfghjkl;'zxcvbnm,./~!@#$%^&*()_+|QWERTYUIOP{}ASDFGHJKL:\"ZXCVBNM<>?;";
        StringBuilder stringBuilder = new StringBuilder();
        for (int i = 0, lim = primeStream.next(); i < lim; i++)
            stringBuilder.Append(chars[randomStream.next() % chars.Length]);
        return stringBuilder.ToString();
    }
    override public bool eos() {
        return primeStream.eos() || randomStream.eos();
    }
    override public void reset() {
        primeStream.reset();
        randomStream.reset();
    }
}