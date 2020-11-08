using Git.Data;
using Git.ViewModels.Commits;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Git.Services
{
    public class CommitsService : ICommitsService
    {
        private readonly ApplicationDbContext db;

        public CommitsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(string repositoryId, string description, string userId)
        {
            var commit = new Commit
            {
                Description = description,
                CreatedOn = DateTime.Now,
                CreatorId = userId,
                RepositoryId = repositoryId
            };

            this.db.Add(commit);
            this.db.SaveChanges();
        }

        public IEnumerable<CommitsViewModel> GetAll(string userId)
        {
            return this.db.Commits
                .Where(c => c.CreatorId == userId)
                .Select(c => new CommitsViewModel
                {
                    Id = c.Id,
                    Repository = c.Repository.Name,
                    Description = c.Description,
                    CreatedOn = c.CreatedOn
                }).ToList();
        }

        public void Delete(string commitId, string userId)
        {

            var commit = this.db.Commits.Find(commitId);
            if (commit.CreatorId != userId)
            {
                return;
            }

            this.db.Commits.Remove(commit);
            this.db.SaveChanges();
        }

    }
}
