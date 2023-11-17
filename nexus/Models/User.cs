namespace nexus.Models
{
    public class User
    {
        public int Id { get; set; }

        // Basic Information
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        public bool IsEmployee { get; set; } // Flag indicating employee status

        // Personal Information
        public string? FullName { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }

        // Additional Details
        public bool IsActive { get; set; }
        public DateTime RegistrationDate { get; set; }

        // Payment Information (Can be in a separate PaymentDetails model)
        public string? PaymentCardNumber { get; set; }
        public DateTime PaymentCardExpiry { get; set; }
        public string? PaymentCardCVV { get; set; }

        // Preferences
        public string? PreferredLanguage { get; set; }
        public string? ThemePreference { get; set; }
        public bool ReceivePromotionalEmails { get; set; }

        // Other properties as needed...
    }


}
