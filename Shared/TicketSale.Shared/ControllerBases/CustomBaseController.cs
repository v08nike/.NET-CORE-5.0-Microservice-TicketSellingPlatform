using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using TicketSale.Shared.Dtos;

namespace TicketSale.Shared.ControllerBases
{
    public class CustomBaseController:ControllerBase
    {
        public IActionResult CreatActionResultInstance<T>(Response<T> response)
        {
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }
    }
}
