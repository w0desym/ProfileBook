using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProfileBook
{
    class AuthenticationService : IAuthenticationService
    {
        private IRepositoryService<User> _repositoryService;
        public AuthenticationService(IRepositoryService<User> repositoryService)
        {
            _repositoryService = repositoryService;
        }
        public int Authenticate(string login, string password)
        {
            return _repositoryService.FindUser(login, password);
        }
    }
}
