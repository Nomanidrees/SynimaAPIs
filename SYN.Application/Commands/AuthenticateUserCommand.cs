using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using SYN.Application.DTOs;
using SYN.Application.Interfaces;
using SYN.Domain.Interfaces;

namespace SYN.Application.Commands
{
    public record AuthenticateUserCommand(LoginRequestDto loginRequest) : IRequest<LoginResponseDto>;

    public class AuthenticateUserCommandHandler : IRequestHandler<AuthenticateUserCommand, LoginResponseDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenService _jwtTokenService;

        // Constructor for DI
        public AuthenticateUserCommandHandler(IUserRepository userRepository, IJwtTokenService jwtTokenService)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _jwtTokenService = jwtTokenService ?? throw new ArgumentNullException(nameof(jwtTokenService));
        }

        public async Task<LoginResponseDto> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
        {
            if (request?.loginRequest == null)
                throw new ArgumentNullException(nameof(request.loginRequest), "Login request cannot be null.");

            if (_userRepository == null)
                throw new InvalidOperationException("User repository is not initialized.");

            var user = await _userRepository.GetUserForLoginAsync(request.loginRequest.UserName);

            if (user == null || !BCrypt.Net.BCrypt.Verify(request.loginRequest.Password, user.PasswordHash))
                throw new UnauthorizedAccessException("Invalid credentials.");

            var (token, expiry) = _jwtTokenService.GenerateToken(user.UserEmail, user.UserRole);
            return new LoginResponseDto
            {
                authenticated = true,
                UserRole = user.UserRole,
                UserName = user.UserName,
                DisplayName = user.DisplayName,
                Token = token,
                TokenExpiry = expiry // Set the token expiry in the response
            };
        }

    }
}
