using probne_kolokwium.Entities.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace probne_kolokwium.Services
{
    public interface IRepoService
    {
        IQueryable<Member> GetMemberById(int id);

        IQueryable<Organization> GetOrganizationById(int id);

        IQueryable<Team> GetTeamById (int id);
        Task SaveChangesAsync();

        Task CreateAsync<T>(T entity) where T : class;
    }
}
