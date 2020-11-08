using Git.Data;
using Git.ViewModels.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Git.Services
{
    public class RepositoryService : IRepositoryService
    {
        private readonly ApplicationDbContext db;

        public RepositoryService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(string name, string repositoryType, string userId)
        {
            var repository = new Repository
            {
                Name = name,
                CreatedOn = DateTime.Now,
                IsPublic = repositoryType == "Public" ? true : false,
                OwnerId = userId,
            };

            this.db.Repositories.Add(repository);
            this.db.SaveChanges();
        }

        public IEnumerable<RepositoryViewModel> GetAll()
        {
            return this.db.Repositories
                .Where(r => r.IsPublic == true)
                .Select(r => new RepositoryViewModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    Owner = r.Owner.Username,
                    CreatedOn = r.CreatedOn,
                    CommitsCount = r.Commits.Count()
                }).ToList();
        }

        public Repository GetById(string id)
        {
            return this.db.Repositories.FirstOrDefault(r => r.Id == id);
        }

        public string GetNameById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
