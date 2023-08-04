namespace Mc2.CrudTest.Dto
{
    public class BaseCommandResponse
    {
        public bool Success { get; set; } = true;
        public string Message { get; set; } = "Modification is successful";
    }
}
