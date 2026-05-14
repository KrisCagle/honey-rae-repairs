namespace HoneyRaesAPI.Models;

public class ServiceTicket
{
public int Id { get; set; }
public int CustomerId { get; set; }
public int? EmployeeId { get; set; }  // Remove the ? - make it non-nullable
public string Description { get; set; }
public bool Emergency { get; set; }
public DateTime? DateCompleted { get; set; }  // Remove the ? - make it non-nullable
public Employee Employee { get; set; }
}