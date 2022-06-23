using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using probne_kolokwium.DTOs;
using probne_kolokwium.Entities.Models;
using probne_kolokwium.Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace probne_kolokwium.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {

        private readonly IRepoService _service;

        public TeamsController(IRepoService service)
        {
            _service = service;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(
                await _service.GetTeamById(id)
                .Select(e =>
                new TeamGet
                {
                    TeamName = e.TeamName,
                    TeamDesciption = e.TeamDescription,
                    Organization = e.Organization.OrganizationName,
                    Members = e.Memberships.Select(e => new DTOs.Member
                    {
                        MemberID = e.MemberID,                   
                        MemberName = e.Member.MemberName,
                        MemberSurname = e.Member.MemberSurname
                    }).ToList()
                }).ToListAsync()
            );
        }
    }
}
