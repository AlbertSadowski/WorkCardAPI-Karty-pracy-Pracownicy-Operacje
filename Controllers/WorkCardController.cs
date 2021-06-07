using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkCardAPI.Entities;
using WorkCardAPI.Models;
using WorkCardAPI.Services;

namespace WorkCardAPI.Controllers
{
    [Route("api/workcard")]
    public class WorkCardController : ControllerBase
    {

        private readonly IWorkCardService _workCardService;

        public WorkCardController(IWorkCardService workCardService)
        {
            _workCardService = workCardService;
        }
        
        [HttpPut("{id}")]
        public ActionResult Update([FromRoute] int id, [FromBody] UpdateWorkCardDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var isUpdated =_workCardService.Update(id, dto);
            if (isUpdated)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            var isDeleted = _workCardService.Delete(id);
            if (isDeleted)
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult CreateWorkCard([FromBody] CreateWorkCardDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var id = _workCardService.Create(dto);

            return Created($"/api/workcard/{id}", null);

        }

        [HttpGet]
        public ActionResult<IEnumerable<WorkCardDto>> GetAll()
        {
            var workCardDtos = _workCardService.GetAll();

            return Ok(workCardDtos);
        }
        
        [HttpGet("{id}")]
        public ActionResult<WorkCardDto> Get([FromRoute]int id)
        {
            var workCardDto = _workCardService.GetById(id);

            if (workCardDto is null) return NotFound();

            return Ok(workCardDto);
        }

    }
}
