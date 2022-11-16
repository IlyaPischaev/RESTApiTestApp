using System.ComponentModel.DataAnnotations;

namespace RESTApiTestApp.Models
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }
    }
}
