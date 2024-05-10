namespace Identity.API.DataTransferObjects.Auth
{
    public record LoginDTO(
         string PhoneNumber,
         string Password
    );
}
