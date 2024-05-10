namespace Identity.API.DataTransferObjects.Auth
{
    public record TokenDTO(
        string AccessToken,
        string RefreshToken,
        DateTime ExpireDate
    );
}
