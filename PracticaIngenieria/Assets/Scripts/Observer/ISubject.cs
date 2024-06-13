public interface ISubject
{
    public void AddObserver(IObserver o);
    public void RemoveObserver(IObserver o);
    public void NotifyObservers();

}