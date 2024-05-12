namespace Identity.API.DataTransferObjects.Auth
{
    public record ProfileInfoDTO(
        long Id,
        string FirstName,
        string PhoneNumber,
        string? LastName,
        string? Username,
        string? Email
    );
}
