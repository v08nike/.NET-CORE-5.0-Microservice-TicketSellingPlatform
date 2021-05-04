using IdentityModel.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketSale.Shared.Dtos;
using TicketSale.Web.Models;

namespace TicketSale.Web.Services.Interfaces
{
    interface IIdentityService
    {
        Task<Response<bool>> SignIn(SigninInput signinInput) ;

        Task<TokenResponse> GetAccessTokenByRefreshToken();

        Task RevokeRefreshToken();


    }
}
