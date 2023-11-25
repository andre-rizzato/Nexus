
namespace nexus.Dtos.RequestsDtos
{

    public class CreateUserRequestDto
    {
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool IsEmployee { get; set; }
        public bool IsActive { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string? FullName { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? PaymentCardNumber { get; set; }
        public DateTime PaymentCardExpiry { get; set; }
        public string? PaymentCardCVV { get; set; }
        public string? PreferredLanguage { get; set; }
        public string? ThemePreference { get; set; }
        public bool ReceivePromotionalEmails { get; set; }
        
    }

}