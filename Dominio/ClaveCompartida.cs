namespace Dominio
{
    public class ClaveCompartida
    {
        public Usuario Original { get; set; }
        public Usuario Destino { get; set; }
        public Clave Clave { get; set; }

        public override bool Equals(object objeto)
        {
            if (objeto == null) throw new ObjetoIncompletoException();
            if (objeto.GetType() != this.GetType()) throw new ObjetoIncorrectoException();
            ClaveCompartida aIgualar = (ClaveCompartida)objeto;
            bool igualOriginal = this.Original.Equals(aIgualar.Original);
            bool igualDestino = this.Destino.Equals(aIgualar.Destino);
            bool igualClave = this.Clave.Equals(aIgualar.Clave);
            return (igualOriginal && igualDestino && igualClave);
        }
    }
}
