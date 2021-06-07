using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkCardAPI.Models;
using WorkCardAPI.Services;

namespace WorkCardAPI.Controllers
{
    [Route("/api/workcard/{workCardId}/operation")]
    [ApiController]
    public class OperationsController : ControllerBase
    {
        private readonly IOperationService _operationService;

        public OperationsController(IOperationService operationService)
        {
            _operationService = operationService;
        }

        [HttpDelete]
        public ActionResult Delete([FromRoute] int workCardId)
        {
            var isDeleted = _operationService.RemoveAll(workCardId);

            if (!isDeleted)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        public ActionResult Post([FromRoute] int workCardId, [FromBody] CreateOperationDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var isCreated =_operationService.Create(workCardId, dto);

            if (!isCreated)
            {
                return NotFound();
            }

            return Created($"/api/workcard/{workCardId}/operation", null);
        }

        [HttpGet("{operationId}")]
        public ActionResult<OperationDto> Get([FromRoute] int workCardId, [FromRoute] int operationId)
        {
            var operationDto = _operationService.GetById(workCardId, operationId);

            if(operationDto is null)
            {
                return NotFound();
            }

            return Ok(operationDto);
        }

        [HttpGet]
        public ActionResult<List<OperationDto>> GetAll([FromRoute] int workCardId)
        {
            var operationDtos = _operationService.GetAll(workCardId);

            if(operationDtos is null)
            {
                return NotFound();
            }

            return operationDtos;
        }

    }
}
