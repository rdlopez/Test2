using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class UploadFile :BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [ConcurrencyCheck]
        public int Status { get; set; }
    }
}
