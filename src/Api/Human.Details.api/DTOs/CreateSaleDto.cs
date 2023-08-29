namespace Human.Details.api.DTOs;

public class CreateSaleDto
{
    public int Total { get; set; }
    public int EmployeeId { get; set; }
    public CreateEmployeeDto EmployeeDto { get; set; }
   //public Employee Employee { get; set; }
}