using CustomerService.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using MediatR;
using CustomerService.Api.Notifications;
using CustomerService.Api.Queries;

namespace CustomerService.Api.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository customerRepository;

        private readonly IMediator mediator;

        public CustomersController(ICustomerRepository customerRepository, IMediator mediator)
        {
            this.customerRepository = customerRepository;
            this.mediator = mediator;
        }      

        [HttpGet("ping")]
        public string Ping()
        {
            return "Pong";
        }

        [HttpGet]
        public async Task<IEnumerable<Customer>> Get()
        {
            var customers = await mediator.Send(new GetCustomersQuery());

            return customers;
        }

        [HttpGet("{pesel:length(11)}")]
        public async Task<ActionResult<Customer>> Get(string pesel)
        {
            var customer = await mediator.Send(new GetCustomerByPeselQuery(pesel));

            //if (customer==null)
            //{
            //    return new NotFoundResult();
            //}

            // return new OkObjectResult(customer);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        // GET api/customers/{id}
        [HttpGet("{id:int}", Name = "GetCustomerById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Customer>> Get(int id)
        {
            var customer = await mediator.Send(new GetCustomerByIdQuery(id));

            //if (customer==null)
            //{
            //    return new NotFoundResult();
            //}

            // return new OkObjectResult(customer);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        // GET localhost:5000/api/customers?pesel=Warsaw&email=Poland
        //[HttpGet]
        //public async Task<ActionResult<Customer>> Get([FromQuery] CustomerSearchCritieria searchCritieria)
        //{
        //    var customers = await customerRepository.Get(searchCritieria);

        //    return Ok(customers);
        //}

        // POST localhost:5000/api/customers
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        [HttpPost]
        public async Task<ActionResult<Customer>> Post(Customer customer)
        {
            await mediator.Publish(new AddCustomerNotification(customer));

            return CreatedAtRoute("GetCustomerById", new { id = customer.Id }, customer);
        }

        // PUT  localhost:5000/api/customers/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }

            await customerRepository.UpdateAsync(customer);

            return NoContent();
        }

        // PATCH localhost:5000/api/customers/{id}
        // http://jsonpatch.com/

        // dotnet add package Microsoft.AspNetCore.JsonPatch
        // Content-Type: application/json-patch+json
        // https://www.npmjs.com/package/jsonpatch

        [HttpPatch("{id}")]
        public async Task<ActionResult> Patch(int id, [FromBody] JsonPatchDocument<Customer> patchCustomer)
        {
            await customerRepository.PatchAsync(id, patchCustomer);

            return NoContent();
        }

        // JSON Merge Patch  
        //public async Task<ActionResult> Patch(int id)
        //{
        //}
    }

}
