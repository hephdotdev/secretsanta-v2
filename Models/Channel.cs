using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SecretSanta.Models {
    public class Channel {
        [Key]
        public string Id { get; set; }
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public bool IsEnabled { get; set; } = true;
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public bool IsCustom { get; set; } = false;
        public string Token { get; set; }
    }
}