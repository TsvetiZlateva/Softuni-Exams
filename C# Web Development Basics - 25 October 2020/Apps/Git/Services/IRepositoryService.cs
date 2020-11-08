using Git.Data;
using Git.ViewModels.Repositories;
using System.Collections.Generic;


namespace Git.Services
{
    public interface IRepositoryService
    {
        void Create(string name, string repositoryType, string userId);

        IEnumerable<RepositoryViewModel> GetAll();

        string GetNameById(string id);

        Repository GetById(string id);
    }
}
