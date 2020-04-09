using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using Microsoft.EntityFrameworkCore;
using record_keep_auth_service;
using record_keep_identity_server.DBO.User;

namespace record_keep_identity_server.Validator
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly UserContext _userContext;
        private readonly IAuthService _authService;

        public ResourceOwnerPasswordValidator(UserContext userContext, IAuthService authService)
        {
            _userContext = userContext;
            _authService = authService;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            try
            {
                var user = await _userContext.UserData.FirstOrDefaultAsync(u => u.Email.Equals(context.UserName));

                if (user == null)
                {
                    context.Result =
                        new GrantValidationResult(TokenRequestErrors.InvalidRequest, "Invalid credentials");
                    return;
                }

                var isValid = _authService.ValidatePassword(context.Password, user.PasswordHash, user.PasswordSalt);

                if (!isValid)
                {
                    context.Result =
                        new GrantValidationResult(TokenRequestErrors.InvalidRequest, "Invalid credentials");
                }

                context.Result = new GrantValidationResult(user.Id.ToString(), "ROPG", GetUserClaims(user));
            }
            catch (Exception)
            {
                context.Result =
                    new GrantValidationResult(TokenRequestErrors.InvalidGrant, "Server error");
            }
        }

        private static IEnumerable<Claim> GetUserClaims(UserData user)
        {
            return new[]
            {
                new Claim(JwtClaimTypes.Email, user.Email),
                new Claim(JwtClaimTypes.Name, user.DisplayName ?? string.Empty),
            };
        }
    }
}