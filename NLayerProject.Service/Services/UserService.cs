﻿using AutoMapper;
using NLayerProject.API.Abstraction;
using NLayerProject.Core.DTOs;
using NLayerProject.Core.Models;
using NLayerProject.Core.Repositories;
using NLayerProject.Core.Services;
using NLayerProject.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Service.Services
{
    public class UserService : Service<User>, IUserService
    {
        //private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<User> _repository;
        private readonly IUserRepository _userRepository;
        private readonly IJwtAuthenticationManager _jwtAuthenticationManager;

        public UserService(IGenericRepository<User> repository, IUnitOfWork unitOfWork, IMapper mapper, IJwtAuthenticationManager jwtAuthenticationManager,
            IUserRepository userRepository) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _repository = repository;
            _jwtAuthenticationManager = jwtAuthenticationManager;
            _userRepository = userRepository;
        }

        public string GeneratePasswordHash(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName))
            {
                throw new ArgumentNullException(nameof(userName));
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException(nameof(userName));
            }

            byte[] userBytes = Encoding.UTF8.GetBytes(userName);
            string userByteString = Convert.ToBase64String(userBytes);
            string smallByteString = $"{userByteString.Take(2)}.{userByteString.Reverse().Take(2)}";
            byte[] smallBytes = Encoding.UTF8.GetBytes(smallByteString);
            byte[] passBytes = Encoding.UTF8.GetBytes(password);

            byte[] hashed = this.GenerateSaltedHash(passBytes, smallBytes);

            return Convert.ToBase64String(hashed);
        }
        //private metodlara test yapmamıza gerek yok
        private byte[] GenerateSaltedHash(byte[] plainText, byte[] salt)
        {
            HashAlgorithm algorithm = new SHA256Managed();

            byte[] plainTextWithSaltBytes =
              new byte[plainText.Length + salt.Length];

            for (int i = 0; i < plainText.Length; i++)
            {
                plainTextWithSaltBytes[i] = plainText[i];
            }
            for (int i = 0; i < salt.Length; i++)
            {
                plainTextWithSaltBytes[plainText.Length + i] = salt[i];
            }

            return algorithm.ComputeHash(plainTextWithSaltBytes);
        }

        public UserDto FindUser(string userName, string password)
        {
            string passHashed = GeneratePasswordHash(userName, password);
            var user = _repository.Where(x => x.UserName == userName && x.Password == passHashed).FirstOrDefault();
            var userDto = _mapper.Map<UserDto>(user);
            return userDto;
        }

        public AuthResponseDto Login(AuthRequestDto request)
        {
            AuthResponseDto responseDto = new AuthResponseDto();
            UserDto user = FindUser(request.UserName, request.Password);
            responseDto = _jwtAuthenticationManager.Authenticate(request.UserName, request.Password);
            responseDto.User = user;

            return responseDto;
        }

        public User SignUp(AuthRequestDto authDto)
        {
            #region Password'un hashli halini veri tabanına göndermek için güncelleme yap
            var passwordHash = GeneratePasswordHash(authDto.UserName, authDto.Password);
            #endregion

            var user = AddAsync(new Core.Models.User
            {
                Email = authDto.Email,
                Password = passwordHash,
                UserName = authDto.UserName,
                TeamId = 1
            });
            return user.Result;
        }
    }
}