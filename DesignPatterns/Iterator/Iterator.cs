namespace DesignPatterns.Iterator;

internal interface IIterator<T>
{
    T? First();
    T? Next();
    bool IsDone();
    T? CurrentItem();
}
