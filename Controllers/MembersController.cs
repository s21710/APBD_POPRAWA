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
    public class MembersController : ControllerBase
    {

        private readonly IRepoService _service;

        public MembersController(IRepoService service)
        {
            _service = service;
        }


        [HttpPost("Teams/{Id}/Members")]
        public async Task<IActionResult> Create(int team_id, MemberPost body)
        {

            if (!ModelState.IsValid)
                return BadRequest("Niepoprawne ciało żądania!");

            if (await _service.GetTeamById(team_id).FirstOrDefaultAsync() is null)
                return NotFound("Nie znaleziono klienta o podanym id");

            if (await _service.GetMemberById(body.MemberID).FirstOrDefaultAsync() is null)
                return NotFound("Nie znaleziono pracownika o podanymn id");

            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    foreach (var organization in body.Organizations)
                    {
                        if (await _service.GetOrganizationById(organization.OrganizationID).FirstOrDefaultAsync().ConfigureAwait(false) is null)
                            return NotFound($"Nie znaleziono organizacji -- ID: {organization.OrganizationID}");


                    }

                    scope.Complete();

                }
                catch (Exception)
                {
                    return Problem("Nieoczekiwany błąd serwera");
                }
            }
            await _service.SaveChangesAsync();

            return NoContent();
        }
    }
}
