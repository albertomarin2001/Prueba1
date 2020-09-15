using System;
using System.ComponentModel.DataAnnotations;

namespace admPregunta1.Models
{
    public enum Places
    {
        Santa_Cruz,
        Montero,
        Concepcion,
        Warnes,
        Porongo,
    };

    public class Marin
    {
        [Key]
        public int marinID { get; set; }

        [Required]
        [Display(Name = "Nombre Completo")]
        [StringLength(24, MinimumLength = 2)]
        public string FriendofMarin { get; set; }

        [Required]
        public Places place { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "Email no Valido")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Cumpleaños")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Birthdate { get; set; }

    }
}