using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

using WebApi.Helpers;
using Microsoft.Extensions.Options;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using WebApi.Services;
using WebApi.Entities;
using WebApi.Models.Users;
using WebApi.Models.Farms;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class FarmsController : ControllerBase
    {
        private IFarmService _farmService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public FarmsController(
            IFarmService farmService,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _farmService = farmService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        
        
        [HttpPost("create")]
        public IActionResult Create([FromBody]FarmModel model)
        {
            // map model to entity
            var farm = _mapper.Map<Farm>(model);

            try
            {
                // create farm
                _farmService.Create(farm);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var farms = _farmService.GetAll();
            var model = _mapper.Map<IList<FarmModel>>(farms);
            return Ok(model);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var farm = _farmService.GetById(id);
            var model = _mapper.Map<FarmModel>(farm);
            return Ok(model);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]FarmModel model)
        {
            // map model to entity and set id
            var farm = _mapper.Map<Farm>(model);
            farm.Id = id;

            try
            {
                // update farm
                _farmService.Update(farm);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _farmService.Delete(id);
            return Ok();
        }
    }
}
