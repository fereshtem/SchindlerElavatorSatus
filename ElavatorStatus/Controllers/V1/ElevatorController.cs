
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Schindler.ElavatorStatus.Domain;
using Schindler.ElavatorStatus.Domain.Extensions;


namespace Schindler.ElavatorStatus.WebService.Controllers.V1
{

    [Route("v1/api/[controller]")]
    [ApiController]
    public class ElevatorController : ControllerBase
    {
        private readonly IElavatoStatusRepository _elavatoStatusRepository;

        public ElevatorController(IElavatoStatusRepository elavatoStatusRepository)
        {
            _elavatoStatusRepository = elavatoStatusRepository.IfNotNull();
        }

        [HttpPost("AddElavatorStatus")]
        [Authorize(Roles = Role.Admin)]
        public ActionResult Post(Schindler.ElavatorStatus.Domain.ElavatorStatus value)
        {
            _elavatoStatusRepository.InsertStatus(value);
            return CreatedAtAction("Get", new { id = value.Id }, value);
        }

        [HttpGet("ElavatoStatus/{id}")]
        public ActionResult<Schindler.ElavatorStatus.Domain.ElavatorStatus> Get(Guid id)
        {
            var item = _elavatoStatusRepository.GetElavatorStatus(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpGet("ElavatoStatus")]
        public ActionResult<IEnumerable<Schindler.ElavatorStatus.Domain.ElavatorStatus>> Get()
        {
            var items = _elavatoStatusRepository.GetStatuses();
            return Ok(items);
        }

        [HttpPut("ElavatoStatus")]
        public ActionResult<Schindler.ElavatorStatus.Domain.ElavatorStatus> UpdateProductQuantity(Schindler.ElavatorStatus.Domain.ElavatorStatus value)
        {
            _elavatoStatusRepository.UpdateElavatorStatus(value);

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Remove(Guid id)
        {
            var existingItem = _elavatoStatusRepository.GetElavatorStatus(id);

            if (existingItem == null)
            {
                return NotFound();
            }

            _elavatoStatusRepository.DeleteElavatorStatus(id);
            return Ok();
        }
    }
}