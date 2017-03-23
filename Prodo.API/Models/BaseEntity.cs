namespace Prodo.API.Models
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            Id = -1;
        }

        public int Id { get; set; }

        public bool IsDeleted { get; set; }
    }
}