using System.Web;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.Source.Models;
using UrlShortener.Source.Services;
using UrlShortener.Source.Utils;

namespace UrlShortener.Source.Controllers;

[ApiController]
[Route("/api/v1/")]
public class UrlController : ControllerBase
{
    private readonly DatabaseService Service;

    public UrlController(DatabaseService service)
    {
        this.Service = service;
    }

    [HttpGet]
    public async Task<List<UrlModel>> GetAll() =>
        await Service.GetAllAsync();

    [HttpGet("{id}")]
    public async Task<IActionResult> GetId(string id)
    { 
        var url = await Service.GetById(id);
        
        if (url is null)
            return NotFound();
        
        return Redirect(url.LongUrl);
    }

    [HttpPost("{url}")]
    public async Task<IActionResult> Create(string url)
    {
        var finUrl = HttpUtility.UrlDecode(url);
        var check = await Validator.ValidateUrl(finUrl);
        if (!check)
            return NotFound();

        var newId = IdCreator.IdGen(false);

        var newUrl = new UrlModel
        {
            LongUrl = finUrl,
            ShortUrl = $"https://localhost:3000/api/v1/{newId}",
            ShortId = newId
        };

        await Service.CreateUrl(newUrl);

        return Ok();
    }
}
