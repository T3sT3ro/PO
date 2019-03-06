public abstract class Stream<T>{
    public abstract T next();
    public abstract bool eos();
    public abstract void reset();
}