using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.Shopping.Core.DTOs;
using UESAN.Shopping.Core.Entities;
using UESAN.Shopping.Core.Interfaces;

namespace UESAN.Shopping.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserAuthResponseDTO> Validate(string email, string password)
        {
            var user = await _userRepository.SignIn(email, password);
            if (user == null)
                return null;

            //TODO: Generar Token
            var token = "";

            var userDTO = new UserAuthResponseDTO()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Country = user.Country,
                DateOfBirth = user.DateOfBirth,
                Address = user.Address,
                Token = token
            };
            return userDTO;
        }

        public async Task<bool> Register(UserAuthRequestDTO userDTO)
        {
            //Validación para registro
            var emaiResult = await _userRepository.IsEmailRegistered(userDTO.Email);
            if (emaiResult)
                return false;

            var user = new User()
            {
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                Email = userDTO.Email,
                Country = userDTO.Country,
                Address = userDTO.Address,
                DateOfBirth = userDTO.DateOfBirth,
                Password = userDTO.Password,
                IsActive = true,
                Type = "U"
            };

            var result = await _userRepository.SignUp(user);
            return result;
        }
    }
}