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
                user.Username = requestDto.Username;
                user.Email = requestDto.Email;
                user.IsEmployee = requestDto.IsEmployee;
                user.FullName = requestDto.FullName;
                user.Address = requestDto.Address;
                user.RegistrationDate = requestDto.RegistrationDate;
                user.PhoneNumber = requestDto.PhoneNumber;
                user.DateOfBirth = requestDto.DateOfBirth;
                user.PaymentCardNumber = requestDto.PaymentCardNumber;
                user.PaymentCardExpiry = requestDto.PaymentCardExpiry;
                user.PaymentCardCVV = requestDto.PaymentCardCVV;
                user.PreferredLanguage = requestDto.PreferredLanguage;
                user.ThemePreference = requestDto.ThemePreference;
                user.ReceivePromotionalEmails = requestDto.ReceivePromotionalEmails;

                _userRepository.Update(user);

                return Ok(new { message = $"User updated successfully! user id: {id}", user });
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        // DELETE api/user/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var user = _userRepository.GetById(id);

            if (user == null)
            {
                return NotFound();
            }

            _userRepository.Delete(user);

            return Ok($"User deleted successfully! user id: {id}");
        }
    }


}



