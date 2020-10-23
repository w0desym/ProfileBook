namespace ProfileBook
{
    class AuthorizationService : IAuthorizationService
    {
        private readonly ISettingsManager _settingsManager;
        private readonly IRepositoryService<User> _repositoryService;
        public AuthorizationService(ISettingsManager settingsManager,
            IRepositoryService<User> repositoryService)
        {
            _settingsManager = settingsManager;
            _repositoryService = repositoryService;
        }
        public int Authorize(int id)
        {
            return _settingsManager.CurrentUser = id;
        }
        public int Register(User item)
        {
            if (item.Id != 0)
            {
                _repositoryService.UpdateItem(item);
                return item.Id;
            }
            else
            {
                return _repositoryService.InsertItem(item);
            }
        }
    }
}
