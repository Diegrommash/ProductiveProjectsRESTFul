using Application.Features.TypeMeasurementUnits.Commands.CreateTypeMeasurementUnitCommand;
using Application.Features.TypeMeasurementUnits.Commands.DeleteTypeMeasurementUnitCommand;
using Application.Features.TypeMeasurementUnits.Commands.UpdateTypeMeasurementUnitCommand;
using Application.Features.TypeMeasurementUnits.Queries.GetAllMeasurementUnitQuery;
using Application.Features.TypeMeasurementUnits.Queries.GetTypeMeasurementUnitByIdQuery;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class TypeMeasurementUnitController : BaseApiController
    {

        //Get api/<controller>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetTypeMeasurementUnitByIdQuery{Id = id}));
        }

        //Get api/<controller>
        [HttpGet()]
        public async Task<IActionResult> Get([FromQuery] GetAllTypeMeasurementUnitParameters filter)
        {
            return Ok(await Mediator.Send(new GetAllTypeMeasurementUnitQuery 
            { 
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize,
                Name = filter.Name

            }));
        }

        //Post api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateTypeMeasurementUnitCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        //Put api/<controller>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateTypeMeasurementUnitCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            return Ok(await Mediator.Send(command));
        }

        //Put api/<controller>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteTypeMeasurementUnitCommand { Id = id}));
        }
    }
}
