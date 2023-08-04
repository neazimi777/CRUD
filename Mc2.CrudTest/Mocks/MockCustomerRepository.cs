using Mc2.CrudTest.Domain;
using Mc2.CrudTest.Domain.Repositories;
using Moq;
using XAct.Messages;

namespace Mc2.CrudTest.UnitTest.Mocks
{
    public static class MockCustomerRepository
    {
        public static Mock<ICustomerRepository> CustomerRepository()
        {
            var customers = new List<Domain.Customer>
            {
                new Domain.Customer
                {
                    Id= 1,
                    FirstName= "Ali",
                    LastName="esfandiyar",
                    Email="Ali@gmail.com",
                    PhoneNumber="09125698189",
                    BankAccountNumber="12345678",
                    DateOfBirth=DateOnly.Parse("1998/01/02"),
                    IsActive=true,
                    CreateTime= DateTime.Now,
                    LastModificationTime=null,
                    CheckDuplicate="ED076287532E86365E841E92BFC50D8C"

                },
                 new Domain.Customer
                {
                    Id= 2,
                    FirstName= "maryam",
                    LastName="Ghasemi",
                    Email="maryam@gmail.com",
                    PhoneNumber="09125691289",
                    BankAccountNumber="123456444",
                    DateOfBirth=DateOnly.Parse("1988/01/02"),
                    IsActive=true,
                    CreateTime= DateTime.Now,
                    LastModificationTime=null,
                    CheckDuplicate="ED076287532E86347W941E92BFC50D8C"

                }
            };
            var mockRepo = new Mock<ICustomerRepository>();

            mockRepo.Setup(r => r.GetAll()).ReturnsAsync(customers);
            mockRepo.Setup(r => r.Get(It.IsAny<int>()))
                .Returns((int id) => Task.FromResult(customers.FirstOrDefault(e => e.Id == id)));

            mockRepo.Setup(r => r.Add(It.IsAny<Domain.Customer>())).ReturnsAsync((Domain.Customer customer) =>
            {
                customers.Add(customer);
                return customer;
            });

            mockRepo.Setup(r => r.Update(It.IsAny<Domain.Customer>()))
            .Callback((Domain.Customer customer) =>
            {
                var existingEntity = customers.FirstOrDefault(e => e.Id == customer.Id);
                if (existingEntity != null)
                {
                    existingEntity.FirstName = customer.FirstName;
                    existingEntity.LastName = customer.LastName;
                    existingEntity.Email = customer.Email;
                    customer.IsActive = existingEntity.IsActive;
                }
            });
            return mockRepo;

        }
    }
}
