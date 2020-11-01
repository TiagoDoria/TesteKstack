namespace Kstack.Repository
{
    public class KstackRepository : IKstackRepository
    {
        public double CalcularDistancia(double tempo, double velocidade) 
        {
            return tempo * velocidade;
        }
        
        public double CalcularLitros(double distancia, double kmPorLitro) 
        {
            return distancia / kmPorLitro;
        }
    }
}