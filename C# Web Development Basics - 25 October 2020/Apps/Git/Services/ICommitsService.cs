using Git.ViewModels.Commits;
using System.Collections.Generic;


namespace Git.Services
{
    public interface ICommitsService
    {
        void Create(string repositoryId, string description, string userId);

        IEnumerable<CommitsViewModel> GetAll(string userId);

        void Delete(string commitId, string userId);
    }
}
