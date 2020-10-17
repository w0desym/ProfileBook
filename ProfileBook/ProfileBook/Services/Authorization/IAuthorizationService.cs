namespace ProfileBook
{
    public interface IAuthorizationService
    {
        int Authorize(int id);
        int Register(User item);
    }
}
