using System.Collections.Generic;

namespace ProfileBook
{
    public interface IProfileService
    {
        int SaveProfile(Profile profile);
        int DeleteProfile(int id);
        IEnumerable<Profile> GetProfiles();
        IEnumerable<Profile> SortProfiles();
    }
}
