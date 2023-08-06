namespace Mc2.CrudTest.Dto.EventCustomer
{
    public class BaseCustomerEventDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string DateOfBirth { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string BankAccountNumber { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public DateTime? CreateTime { get; set; }
    }
}
