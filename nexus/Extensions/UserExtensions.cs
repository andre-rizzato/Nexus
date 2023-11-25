
using nexus.Dtos.RequestsDtos;
using nexus.Dtos.ResponseDtos;
using nexus.Models;

namespace nexus.Extensions
{
    public static class UserExtensions
    {
        public static CreateUserRequestDto ToCreateUserRequestDto(this User user)
        {
            return new CreateUserRequestDto
            {
                Username = user.Username,
                Email = user.Email,
                Password = user.PasswordHash,
                FullName = user.FullName,
                Address = user.Address,
                PhoneNumber = user.PhoneNumber,
                DateOfBirth = user.DateOfBirth,
                IsActive = user.IsActive,
                RegistrationDate = user.RegistrationDate,
                PaymentCardNumber = user.PaymentCardNumber,
                PaymentCardExpiry = user.PaymentCardExpiry,
                PaymentCardCVV = user.PaymentCardCVV,
                PreferredLanguage = user.PreferredLanguage,
                ThemePreference = user.ThemePreference,
                ReceivePromotionalEmails = user.ReceivePromotionalEmails
            };
        }

        public static CreateUserResponseDto ToCreateUserResponseDto(this User user)
        {
            return new CreateUserResponseDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                FullName = user.FullName,
                Address = user.Address,
                PhoneNumber = user.PhoneNumber,
                DateOfBirth = user.DateOfBirth,
                IsActive = user.IsActive,
                RegistrationDate = user.RegistrationDate,
                PreferredLanguage = user.PreferredLanguage,
                ThemePreference = user.ThemePreference,
                ReceivePromotionalEmails = user.ReceivePromotionalEmails
            };
        }
    }
}