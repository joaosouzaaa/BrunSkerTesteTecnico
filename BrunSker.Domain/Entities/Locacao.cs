using BrunSker.Domain.Entities.EntitiesBase;

namespace BrunSker.Domain.Entities
{
    public class Locacao : BaseEntity
    {
        public decimal Preco { get; set; }
        public bool EstaLocado { get; set; }

        public Endereco Endereco{ get; set; }
    }
}
