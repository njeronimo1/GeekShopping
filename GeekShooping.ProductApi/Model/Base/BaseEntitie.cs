using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShooping.ProductApi.Model.Base
{
    public class BaseEntitie
    {
        [Key]
        [Column("id")]
        public long id { get; set; }

    }
}
