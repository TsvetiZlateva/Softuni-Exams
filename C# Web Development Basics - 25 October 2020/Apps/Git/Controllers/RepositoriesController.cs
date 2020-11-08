using Git.Services;
using SUS.HTTP;
using SUS.MvcFramework;
using System;

namespace Git.Controllers
{
    public class RepositoriesController: Controller
    {
        private readonly IRepositoryService repositoryService;

        public RepositoriesController(IRepositoryService repositoryService)
        {
            this.repositoryService = repositoryService;
        }

        public HttpResponse All()
        {
            var repositories = this.repositoryService.GetAll();
            return this.View(repositories);
        }

        public HttpResponse Create()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(string name, string repositoryType)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrWhiteSpace(name) || name.Length < 3 || name.Length > 10)
            {
                return this.Error("Name should be between 5 and 20 characters.");
            }

            if (String.IsNullOrWhiteSpace(repositoryType))
            {
                return this.Error("Repository type is required!");
            }

            var userId = this.GetUserId();
            this.repositoryService.Create(name, repositoryType, userId);
            return this.Redirect("/Repositories/All");
        }
    }
}
