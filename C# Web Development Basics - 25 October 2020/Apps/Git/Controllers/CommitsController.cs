using Git.Services;
using SUS.HTTP;
using SUS.MvcFramework;

namespace Git.Controllers
{
    public class CommitsController: Controller
    {
        private readonly IRepositoryService repositoryService;
        private readonly ICommitsService commitsService;

        public CommitsController(IRepositoryService repositoryService, ICommitsService commitsService)
        {
            this.repositoryService = repositoryService;
            this.commitsService = commitsService;
        }

        public HttpResponse All()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.GetUserId();
            var commits = this.commitsService.GetAll(userId);
            return this.View(commits);
        }

        public HttpResponse Create(string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var repository = this.repositoryService.GetById(id);
            return this.View(repository);
        }

        [HttpPost]
        public HttpResponse Create(string id, string description)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrEmpty(description) || description.Length < 5)
            {
                return this.Error("Description is required and should be at least 5 characters long.");
            }

            var userId = this.GetUserId();
            this.commitsService.Create(id, description, userId);
            return this.Redirect("/Repositories/All");
        }

       
        public HttpResponse Delete(string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.GetUserId();
            this.commitsService.Delete(id, userId);
            return this.Redirect("/Commits/All");
        }
    }
}
