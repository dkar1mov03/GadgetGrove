namespace GadgetGrove.Service.DTOs.Registrations.UserRegistrations;

public class UserRegistrationForCreationDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public decimal AccountBalance { get; set; }
    public string PhoneNumber { get; set; }
    public string VerificationCode { get; set; }
}
