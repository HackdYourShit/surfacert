using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace MVCSurfaceRTStore.Models
{
    [Table("UserProfile")]
    public class UserProfile
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string AddressStreet { get; set; }
        public string AddressHouse { get; set; }
        public string AddressZip { get; set; }
        public string AddressTown { get; set; }
        public string Phonenumber { get; set; }
    }

    public class RegisterExternalLoginModel
    {
        [Required]
        [Display(Name = "Gebruikersnaam")]
        public string UserName { get; set; }

        public string ExternalLoginData { get; set; }
    }

    public class LocalPasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Huidig wachtwoord")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Het {0} moet minimaal {2} karakters lang zijn", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nieuwe wachtwoord")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Bestiging nieuwe wachtwoord")]
        [Compare("NewPassword", ErrorMessage = "Het nieuwe wachtwoord en de bevestiging matchen niet!")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginModel
    {
        [Required]
        [Display(Name = "Gebruikersnaam")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Wachtwoord")]
        public string Password { get; set; }

        [Display(Name = "Onthouden?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        [Display(Name = "Gebruikersnaam")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Het {0} moet minimaal {2} karakters lang zijn.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Bevestig password")]
        [Compare("Password", ErrorMessage = "Het nieuwe wachtwoord en de bevestiging matchen niet!")]
        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "U heeft geen voornaam ingevuld.", MinimumLength = 1)]
        [DataType(DataType.Text)]
        [Display(Name = "Voornaam")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "U heeft geen achternaam ingevuld.", MinimumLength = 1)]
        [DataType(DataType.Text)]
        [Display(Name = "Achternaam")]
        public string SecondName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "U heeft geen e-mailadres ingevuld.", MinimumLength = 1)]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "U heeft geen geldig e-mailadres ingevuld.")]
        [Display(Name = "E-mailadres")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "U heeft geen straat ingevuld.", MinimumLength = 1)]
        [DataType(DataType.Text)]
        [Display(Name = "Straat")]
        public string Street { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "U heeft geen huisnummer ingevuld.", MinimumLength = 1)]
        [DataType(DataType.Text)]
        [Display(Name = "Huisnummer")]
        public string HouseNumber { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "U heeft geen postcode ingevuld.", MinimumLength = 1)]
        [RegularExpression("^[0-9]{4}[a-z|A-Z]{2}$", ErrorMessage = "U heeft geen geldige postcode ingevuld")]
        [Display(Name = "Postcode")]
        public string ZipCode { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "U heeft geen postcode ingevuld.", MinimumLength = 1)]
        [DataType(DataType.Text)]
        [Display(Name = "Woonplaats")]
        public string Town { get; set; }
        
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefoonnummer")]
        public string PhoneNumber { get; set; }
    }

    public class ExternalLogin
    {
        public string Provider { get; set; }
        public string ProviderDisplayName { get; set; }
        public string ProviderUserId { get; set; }
    }
}
