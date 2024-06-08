namespace DiscograficaWebApi.DAL.Models
{
    public abstract class EntidadBase
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public DateTime CreatedTime { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedTime { get; set; }
    }
}
