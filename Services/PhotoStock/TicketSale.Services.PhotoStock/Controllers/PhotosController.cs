using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TicketSale.Services.PhotoStock.Dto;
using TicketSale.Shared.ControllerBases;
using TicketSale.Shared.Dtos;

namespace TicketSale.Services.PhotoStock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosController : CustomBaseController
    {
        [HttpPost]
        public async Task<IActionResult> PhotoSave(IFormFile photo, CancellationToken cancellationToken)
        {
            if (photo != null && photo.Length > 0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/photos", photo.FileName);

                using var stream = new FileStream(path, FileMode.Create);

                await photo.CopyToAsync(stream, cancellationToken);

                var returnPath = "photos/" + photo.FileName;

                PhotoDto photoDto = new()
                {
                    Url = returnPath
                };
                return CreatActionResultInstance(Response<PhotoDto>.Success(photoDto, 200));
            }
            return CreatActionResultInstance(Response<PhotoDto>.Fail("photo is empty", 400));

        } 
    
        public IActionResult PhotoDelet(string photoUrl)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/photos",photoUrl);
            if (System.IO.File.Exists(path))
            {
                return CreatActionResultInstance(Response<NoContent>.Fail("photo not found", 404));
            }

            System.IO.File.Delete(path);
            return CreatActionResultInstance(Response<NoContent>.Success( 204));

        }
    
    }
}
