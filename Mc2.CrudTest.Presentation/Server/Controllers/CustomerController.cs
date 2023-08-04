using Mc2.CrudTest.DomainService.Customer.Requests.Commands;
using Mc2.CrudTest.DomainService.Customer.Requests.Queries;
using Mc2.CrudTest.Dto;
using Mc2.CrudTest.Dto.Customer;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Mc2.CrudTest.Presentation.Server.Controllers
{
    /// <summary>
    ///  controller for al API Customer classe 
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController, Produces("application/json")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// constructor for CustomerController
        /// </summary>
        /// <param name="mediator"></param>
        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Delete Customer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<BaseCommandResponse>> Delete(int id)
        {
            var response = await _mediator.Send(new DeleteCustomerRequest(id));
            return Ok(response);
        }

        /// <summary>
        /// Create Customer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost()]
        public async Task<ActionResult<BaseCommandResponse>> Create(CreateCustomerDto createCustomerDto)
        {
            var response = await _mediator.Send(new CreateCustomerRequest(createCustomerDto));
            return Ok(response);
        }

        /// <summary>
        /// Edit Customer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut()]
        public async Task<ActionResult<BaseCommandResponse>> Update(UpdateCustomerDto updateCustomerDto)
        {
            var response = await _mediator.Send(new UpdateCustomerRequest(updateCustomerDto));
            return Ok(response);
        }
        /// <summary>
        /// Get Customer by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<ActionResult<GetCustomerDto>> Get(int id)
        {
            var response = await _mediator.Send(new GetCustomerRequest(id));
            return Ok(response);
        }
    }
}
