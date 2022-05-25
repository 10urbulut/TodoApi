using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Todo.Core
{
    public class BaseEntity<T> where T : struct
    {
        [Key]
        public T Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? IsDeleted { get; set; }
        
    }
}
