namespace ProfileBook
{
    public interface IAuthorizationService
    {
        void Authorize(int id);
        int Registrate(User item);
    }
}
