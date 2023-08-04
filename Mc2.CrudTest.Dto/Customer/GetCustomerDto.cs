namespace Mc2.CrudTest.Dto.Customer
{
    public class GetCustomerDto: BaseCustomerDto
    {
        public DateTime? CreateTime { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public bool IsActive { get; set; }
    }
}
