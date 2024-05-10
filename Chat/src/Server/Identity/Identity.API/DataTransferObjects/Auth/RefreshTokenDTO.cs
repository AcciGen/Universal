namespace Identity.API.DataTransferObjects.Auth
{
    public record RefreshTokenDTO(
        string AccessToken,
        string RefreshToken
    );
}
