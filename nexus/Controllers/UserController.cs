using Microsoft.AspNetCore.Mvc;
using nexus.Dtos.RequestsDtos;
using nexus.Models;
using nexus.Extensions;
using nexus.Repositories.Interfaces;
using nexus.Dtos.ResponseDtos;

namespace nexus.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private IUserRepository _userRepository { get; set; }

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET api/user/5
        [HttpGet("{id}")]
        public ActionResult<CreateUserResponseDto> GetById(int id)
        {
            return Ok(_userRepository.GetById(id).ToCreateUserResponseDto());
        }

        // POST api/user
        [HttpPost]
        public CreateUserResponseDto Post([FromBody] CreateUserRequestDto requestDto)
        {
            return _userRepository.Add(new User
            {
                Username = requestDto.Username,
                Email = requestDto.Email,
                PasswordHash = HashCode.Combine(requestDto.Password).ToString(),
                IsEmployee = requestDto.IsEmployee,
                FullName = requestDto.FullName,
                Address = requestDto.Address,
                RegistrationDate = requestDto.RegistrationDate,
                PhoneNumber = requestDto.PhoneNumber,
                DateOfBirth = requestDto.DateOfBirth,
                PaymentCardNumber = requestDto.PaymentCardNumber,
                PaymentCardExpiry = requestDto.PaymentCardExpiry,
                PaymentCardCVV = requestDto.PaymentCardCVV,
                PreferredLanguage = requestDto.PreferredLanguage,
                ThemePreference = requestDto.ThemePreference,
                ReceivePromotionalEmails = requestDto.ReceivePromotionalEmails
            }).ToCreateUserResponseDto();
        }

        // PUT api/user/5
        [HttpPut("{id}")]
        public ActionResult<UpdateUserResponseDto> Put(int id, [FromBody] UpdateUserRequestDto requestDto)
        {
            try
            {
                var user = _userRepository.GetById(id);

                if (user == null)
                {
                    return NotFound();
                }

                // Update user properties based on the requestDto
                if (!string.IsNullOrEmpty(requestDto.Username))
                {
                    user.Username = requestDto.Username;
                }

                if (!string.IsNullOrEmpty(requestDto.Email))
                {
                    user.Email = requestDto.Email;
                }

                if (requestDto.IsEmployee != default)
                {
                    user.IsEmployee = requestDto.IsEmployee;
                }

                if (!string.IsNullOrEmpty(requestDto.FullName))
                {
                    user.FullName = requestDto.FullName;
                }

                if (!string.IsNullOrEmpty(requestDto.Address))
                {
                    user.Address = requestDto.Address;
                }

                if (requestDto.RegistrationDate != default)
                {
                    user.RegistrationDate = requestDto.RegistrationDate;
                }

                if (!string.IsNullOrEmpty(requestDto.PhoneNumber))
                {
                    user.PhoneNumber = requestDto.PhoneNumber;
                }

                if (requestDto.DateOfBirth != default)
                {
                    user.DateOfBirth = requestDto.DateOfBirth;
                }

                if (!string.IsNullOrEmpty(requestDto.PaymentCardNumber))
                {
                    user.PaymentCardNumber = requestDto.PaymentCardNumber;
                }

                if (!string.IsNullOrEmpty(requestDto.PaymentCardExpiry.ToString()))
                {
                    user.PaymentCardExpiry = requestDto.PaymentCardExpiry;
                }

                if (!string.IsNullOrEmpty(requestDto.PaymentCardCVV))
                {
                    user.PaymentCardCVV = requestDto.PaymentCardCVV;
                }

                if (!string.IsNullOrEmpty(requestDto.PreferredLanguage))
                {
                    user.PreferredLanguage = requestDto.PreferredLanguage;
                }

                if (!string.IsNullOrEmpty(requestDto.ThemePreference))
                {
                    user.ThemePreference = requestDto.ThemePreference;
                }

                if (requestDto.ReceivePromotionalEmails != default)
                {
                    user.ReceivePromotionalEmails = requestDto.ReceivePromotionalEmails;
                }

                _userRepository.Update(user);

                return Ok(new { message = $"User updated successfully! user id: {id}", user });
            }
            catch (System.Exception)
            {
                throw;
            }
        }

