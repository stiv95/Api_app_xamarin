using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Estiven_API_Xamarin.Data.Models
{
    public class ListUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public long Id { get; set; }

        [Required]
        public string NameList { get; set; }

        public string NameProduct { get; set; }

        public string Marca { get; set; }
        public int Cantidad { get; set; }
        public float ValorUnitario { get; set; }
        public long IdUser { get; set; }

        [ForeignKey(nameof(IdUser))]

        public virtual User? User { get; set; }

  


    }
}
