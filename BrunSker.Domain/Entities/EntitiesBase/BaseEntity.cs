namespace BrunSker.Domain.Entities.EntitiesBase
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
