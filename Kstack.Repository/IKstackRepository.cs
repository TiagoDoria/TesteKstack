namespace Kstack.Repository
{
    public interface IKstackRepository
    {
         double CalcularDistancia(double tempo, double velocidade);
         double CalcularLitros(double distancia, double kmPorLitro);
    }
}