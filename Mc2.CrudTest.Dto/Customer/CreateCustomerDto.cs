namespace Mc2.CrudTest.Dto.Customer
{
    public class CreateCustomerDto: BaseCustomerDto
    {
        public string BankAccountNumber { get; set; } = string.Empty;
    }
}
