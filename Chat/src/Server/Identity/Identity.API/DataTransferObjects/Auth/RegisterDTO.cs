namespace Identity.API.DataTransferObjects.Auth
{
    public record RegisterDTO(
         string FirstName,
         string? LastName,
         string? UserName,
         string PhoneNumber,
         string Password
    );
}
