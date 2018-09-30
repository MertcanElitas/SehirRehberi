 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sehir.Common.Dto;
using Sehir.Core.Services;
using Sehir.Domain.Domains;

namespace SehirRehberi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private IMapper _mapper;
        public CityController(IMapper mapper)
        {
            _mapper = mapper;
        }




        public List<CityDto> GetCities()
        {
            var model = Services.EntityRepository.GetCities();
            return model;
        }

        [HttpPost]
        [Route("add")]
        public ActionResult Add([FromBody]CityDto cityDto)
        {
            var City = new City
            {
                Name = cityDto.Name,
                Description=cityDto.Description,
                userId=cityDto.UserId,
               
            };
            Services.EntityRepository.Add(City);
            Services.EntityRepository.SaveAll();

            return Ok(cityDto);
        }

        [HttpGet]
        [Route("Detail/{id:int}")]
        public ActionResult GetCitiesById(int id)

        {

            var model=Services.EntityRepository.GetById(id);

            return Ok(model);
        }

        [HttpGet]
        [Route("CityPhoto/{cityid:int}")]
        public ActionResult GetCitiesPhoto(int cityid)
        {
            var model = Services.EntityRepository.GetPhotosByCity(cityid);
            return Ok(model);
        }


    }
}