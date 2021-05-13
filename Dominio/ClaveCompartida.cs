namespace Dominio
{
    public class ClaveCompartida
    {
        public Usuario Usuario { get; set; }
        public Clave Clave { get; set; }

        public override bool Equals(object objeto)
        {
            if (objeto == null) throw new ObjetoIncompletoException();
            if (objeto.GetType() != this.GetType()) throw new ObjetoIncorrectoException();
            ClaveCompartida aIgualar = (ClaveCompartida)objeto;
            bool igualUsuario = this.Usuario.Equals(aIgualar.Usuario);
            bool igualClave = this.Clave.Equals(aIgualar.Clave);
            return (igualUsuario && igualClave);
        }
    }
}
