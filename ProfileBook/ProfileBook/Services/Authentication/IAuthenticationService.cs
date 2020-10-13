namespace ProfileBook
{
    public interface IAuthenticationService
    {
        int Authenticate(string login, string password);
    }
}
