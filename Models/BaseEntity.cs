using SQLite;

namespace CarListApp.Models
{
    public abstract class BaseEntity
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    }

}
