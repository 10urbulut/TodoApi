using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Todo.Core
{
    public class BaseEntity<T> where T : struct
    {
        [Key]
        public T Id { get; set; }
        public DateTime CreatedAt { get; set; }
        DateTime? UpdatedAt { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
    }
}
