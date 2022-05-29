using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Comum.Dominio
{
    public abstract class Entidade<T> where T : Entidade<T>
    {
        public int Id { get; set; }

        public virtual bool EhTransiente
        {
            get { return Id == 0; }
        }

        public override bool Equals(object obj)
        {
            var outraEntidade = obj as T;
            if (outraEntidade == null) return false;

            if (EhTransiente && outraEntidade.EhTransiente)
                return ReferenceEquals(this, outraEntidade);

            return Id == outraEntidade.Id;
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public static bool operator ==(Entidade<T> e1, Entidade<T> e2)
        {
            return Equals(e1, e2);
        }

        public static bool operator !=(Entidade<T> e1, Entidade<T> e2)
        {
            return !Equals(e1, e2);
        }

        public virtual T Clonar()
        {
            return (T)this.MemberwiseClone();
        }
    }
}
