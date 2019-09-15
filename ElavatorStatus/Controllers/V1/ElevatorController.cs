
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Schindler.ElavatorStatus.Domain;
using Schindler.ElavatorStatus.Domain.Extensions;
using Schindler.ElavatorStatus.WebService.Model;
using AutoMapper;

namespace Schindler.ElavatorStatus.WebService.Controllers.V1
{

    [Route("v1/api/[controller]")]
    [ApiController]
    public class ElevatorController : ControllerBase
    {
        private readonly IElavatoStatusRepository _elavatoStatusRepository;
        private readonly IMapper _mapper;
        public ElevatorController(IElavatoStatusRepository elavatoStatusRepository, IMapper mapper)
        {
            _elavatoStatusRepository = elavatoStatusRepository.IfNotNull();
            _mapper = mapper;
        }

        [HttpPost("AddElavatorStatus")]
        [Authorize(Roles = Role.Admin)]
        public ActionResult Post(Schindler.ElavatorStatus.Domain.ElavatorStatus value)
        {
            _elavatoStatusRepository.InsertStatus(value);
            return CreatedAtAction("Get", new { id = value.Id }, _mapper.Map<ElavatorStatusModel>(value));
        }

        [HttpGet("ElavatoStatus/{id}")]
        [Authorize(Roles = "Admin, User")]
        public ActionResult<ElavatorStatusModel> Get(Guid id)
        {
            var item = _elavatoStatusRepository.GetElavatorStatus(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ElavatorStatusModel>(item));

        }

        [HttpGet("ElavatoStatus")]
        [Authorize(Roles = "Admin, User")]
        public ActionResult<IEnumerable<ElavatorStatusModel>> Get()
        {
            var items = _elavatoStatusRepository.GetStatuses();
            ICollection<ElavatorStatusModel> icollectionDest = _mapper.Map<List<Schindler.ElavatorStatus.Domain.ElavatorStatus>, ICollection<ElavatorStatusModel>>(items);
            return Ok(icollectionDest);
        }

        [HttpPut("ElavatoStatus")]
        [Authorize(Roles = Role.Admin)]
        public ActionResult UpdateProductQuantity(ElavatorStatusModel value)
        {
            _elavatoStatusRepository.UpdateElavatorStatus(_mapper.Map<Schindler.ElavatorStatus.Domain.ElavatorStatus>(value));

            return Ok();
        }

        [HttpDelete("Remove/{id}")]
        [Authorize(Roles = Role.Admin)]
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