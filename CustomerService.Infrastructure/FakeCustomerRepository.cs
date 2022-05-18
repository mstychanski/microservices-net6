using Bogus;
using Core.Intrastructure;
using CustomerService.Domain;

namespace CustomerService.Infrastructure
{
    public class FakeCustomerRepository : FakeEntityRepository<int, Customer>, ICustomerRepository
    {
        public FakeCustomerRepository(Faker<Customer> faker) : base(faker)
        {
        }

        public Task<IEnumerable<Customer>> Get(CustomerSearchCritieria searchCritieria)
        {
            var customers = _entities.Values.AsQueryable();

            if (!string.IsNullOrEmpty(searchCritieria.FirstName))
            {
                customers = customers.Where(x => x.FirstName == searchCritieria.FirstName);
            }

            if (!string.IsNullOrEmpty(searchCritieria.Pesel))
            {
                customers = customers.Where(x => x.Pesel == searchCritieria.Pesel);
            }

            return Task.FromResult(customers.ToList().AsEnumerable());

        }

        public Task<Customer> GetAsync(string pesel)
        {
            var customer = _entities.Values.SingleOrDefault(e => e.Pesel == pesel);

            return Task.FromResult(customer);
        }
    }
}