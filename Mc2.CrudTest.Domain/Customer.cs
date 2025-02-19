﻿namespace Mc2.CrudTest.Domain
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string BankAccountNumber { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public string CheckDuplicate { get; set; } = string.Empty.ToString();
        public DateTime CreateTime { get; set; }
        public DateTime? LastModificationTime { get; set; }
    }
}
