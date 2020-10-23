using System.Linq;

namespace ProfileBook
{
    class AuthenticationService : IAuthenticationService
    {
        private readonly IRepositoryService<User> _repositoryService;
        public AuthenticationService(IRepositoryService<User> repositoryService)
        {
            _repositoryService = repositoryService;
        }
        public int Authenticate(string login, string password)
        {
            var user = _repositoryService.GetItems().FirstOrDefault(x => x.Login == login && x.Password == password);
            if (user != null)
                return user.Id;
            else
                return 0;
        }
    }
}
