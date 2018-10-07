using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Sehir.Common.Dto.Photo;
using Sehir.Core.Services;
using SehirRehberi.Helper;

namespace SehirRehberi.Controllers
{
    [Route("api/cities/{cityid}/photos")]
    [ApiController]
    public class PhotoController : ControllerBase
    {

        private IOptions<CloudinarySettings> _cloudinaryConfig;
        private Cloudinary _cloudinary;

        public PhotoController(IOptions<CloudinarySettings> cloudinaryConfig)
        {
            _cloudinaryConfig = cloudinaryConfig;

            Account account = new Account(
                _cloudinaryConfig.Value.CloudName,
                _cloudinaryConfig.Value.ApiKey,
                _cloudinaryConfig.Value.ApiSecret);

            _cloudinary = new Cloudinary(account);


        }


        public ActionResult AddPhotoForCity(int cityid,[FromBody]PhotoForCreationDto photoForCreationDto)
        {
            var city = Services.EntityRepository.GetById(cityid);

            if (city == null)
                return BadRequest();

            var currentUserId =int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            if (city.UserId!=currentUserId)
            {
                return Unauthorized();
            }

            var file = photoForCreationDto.File;

            var uploadResult = new ImageUploadResult();

            if (file.Length>0)
            {
                using (var stream=file.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams
                    {
                        File = new FileDescription(file.Name, stream)
                    };

                    uploadResult = _cloudinary.Upload(uploadParams);
                }
            }
            photoForCreationDto.Url = uploadResult.Uri.ToString();
            photoForCreationDto.PublicId = uploadResult.PublicId;
            photoForCreationDto.city = city;
            var result=Services.PhotoService.AddPhoto(photoForCreationDto);

            if (result>0)
            {
                return CreatedAtRoute("GetPhoto", new { id = result, photoForCreationDto });
            }

            return BadRequest();  
                
                }

        [HttpGet("{id}",Name ="GetPhoto")]
        public ActionResult GetPhoto(int id)
        {
            var photoFromDb = Services.EntityRepository.GetPhoto(id);

            return Ok(photoFromDb);
        }


    }
}