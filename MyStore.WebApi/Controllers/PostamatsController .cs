using Microsoft.AspNetCore.Mvc;
using MyStore.Core.Entities;
using MyStore.WebApi.Controllers;
using MyStore.Infrastructure.Repositories.Interfaces;

namespace MyStore.Controllers;

[ApiController]
[Route("postamats")]
public class PostamatsController : BaseController
{
    private readonly IPostamatRepository _postamatRepository;
    public PostamatsController(IPostamatRepository postamatRepository)
    {
        _postamatRepository = postamatRepository;
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Postamat>> GetById(int id)
    {
        var postamat = await _postamatRepository.GetById(id);

        if (postamat == null || postamat.WorkingStatus == false)
        {
            return NotFound();
        }

        return Ok(postamat);
    }

    [HttpGet("working")]
    public async Task<ActionResult> GetWorking()
    {
        var workingPostamats = await _postamatRepository.GetWorking();
        return Ok(workingPostamats);
    }
}