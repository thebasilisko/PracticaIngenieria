public interface IObserver
{
    // Se utiliza un identificador para caracterizar al sujeto, ya que un observador puede estar suscrito a dos sujetos diferentes
    public void UpdateState(int id);
}
