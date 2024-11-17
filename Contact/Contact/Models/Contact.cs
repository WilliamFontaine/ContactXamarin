using System.ComponentModel.DataAnnotations;
using Contact.Helpers;
using SQLite;

namespace Contact.Models
{
    [Table("Contacts")]
    public class Contact : NotificationObject
    {
        private string comment;
        private string email;
        private string firstName;
        private string lastName;
        private string phoneNumber;

        [PrimaryKey]
        [AutoIncrement]
        [Display(AutoGenerateField = false)]
        public int Id { get; set; }

        [SQLite.MaxLength(50)]
        [Required(ErrorMessage = "Le prénom est obligatoire")]
        [StringLength(50, ErrorMessage = "Le prénom ne peut pas dépasser 50 caractères")]
        [Display(Name = "Prénom")]
        public string FirstName
        {
            get => firstName;
            set
            {
                firstName = value;
                RaisePropertyChanged(nameof(FirstName));
            }
        }

        [SQLite.MaxLength(50)]
        [Required(ErrorMessage = "Le nom est obligatoire")]
        [StringLength(50, ErrorMessage = "Le nom ne peut pas dépasser 50 caractères")]
        [Display(Name = "Nom")]
        public string LastName
        {
            get => lastName;
            set
            {
                lastName = value;
                RaisePropertyChanged(nameof(LastName));
            }
        }

        [Required(ErrorMessage = "Le numéro de téléphone est obligatoire")]
        [RegularExpression(@"^0[1-9]([-. ]?[0-9]{2}){4}$", ErrorMessage = "Le numéro de téléphone n'est pas valide")]
        [Display(Name = "Numéro de téléphone")]
        public string PhoneNumber
        {
            get => phoneNumber;
            set
            {
                phoneNumber = value;
                RaisePropertyChanged(nameof(PhoneNumber));
            }
        }

        [Required(ErrorMessage = "L'adresse email est obligatoire")]
        [EmailAddress(ErrorMessage = "L'adresse email n'est pas valide")]
        [Display(Name = "Adresse email")]
        public string Email
        {
            get => email;
            set
            {
                email = value;
                RaisePropertyChanged(nameof(Email));
            }
        }

        [Display(Name = "Commentaire")]
        public string Comment
        {
            get => comment;
            set
            {
                comment = value;
                RaisePropertyChanged(nameof(Comment));
            }
        }
    }
}