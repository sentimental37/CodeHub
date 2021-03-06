using GitHubSharp.Models;
using System.Threading.Tasks;

namespace CodeHub.Core.ViewModels.Organizations
{
    public class TeamsViewModel : LoadableViewModel
    {
        public CollectionViewModel<TeamShortModel> Teams { get; }

        public string OrganizationName { get; private set; }

        public TeamsViewModel()
        {
            Title = "Teams";
            Teams = new CollectionViewModel<TeamShortModel>();
        }

        public void Init(NavObject navObject)
        {
            OrganizationName = navObject.Name;
        }

        protected override Task Load()
        {
            return Teams.SimpleCollectionLoad(this.GetApplication().Client.Organizations[OrganizationName].GetTeams());
        }

        public class NavObject
        {
            public string Name { get; set; }
        }
    }
}