using Microsoft.EntityFrameworkCore;
using probne_kolokwium.Entities;
using probne_kolokwium.Entities.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace probne_kolokwium.Services
{
    public class RepoService : IRepoService
    {
        private readonly RepositoryContext _repository;
        public RepoService(RepositoryContext repository)
        {
            _repository = repository;
        }

        public IQueryable<Team> GetTeamById(int id)
        {
            return _repository.Team.Where(e => e.TeamID == id);
        }

        public IQueryable<Organization> GetOrganizationById(int id)
        {
            return _repository.Organization.Where(e => e.OrganizationID == id);
        }
        public IQueryable<Member> GetMemberById(int id)
        {
            return _repository.Member.Where(e => e.MemberID == id);
        }


        public async Task CreateAsync<T>(T entity) where T : class
        {
            await _repository.Set<T>().AddAsync(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _repository.SaveChangesAsync();
        }

    }
}
