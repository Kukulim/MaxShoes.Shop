using MaxShoes.Shop.Identity.Models.JwtAuthModels;
using System;
using System.Collections.Immutable;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MaxShoes.Shop.Application.Contracts.Identity
{
    public interface IJwtAuthManager
    {
        IImmutableDictionary<string, RefreshToken> UsersRefreshTokensReadOnlyDictionary { get; }

        JwtAuthResult GenerateTokens(string username, Claim[] claims, DateTime now);

        JwtAuthResult Refresh(string refreshToken, string accessToken, DateTime now);

        void RemoveExpiredRefreshTokens(DateTime now);

        void RemoveRefreshTokenByUserEmail(string userName);

        (ClaimsPrincipal, JwtSecurityToken) DecodeJwtToken(string token);

        string GenerateConfirmEmailToken(string username, Claim[] claims, DateTime now);

        string GenerateTemporaryPasswordString();

        string GeneratePasswordResetToken(Claim[] claims, DateTime now);

        string ConfirmEmailToken(string UserName, string Token, DateTime Now);

        string ConfirmPasswordResetToken(string Email, string Token);
    }
}