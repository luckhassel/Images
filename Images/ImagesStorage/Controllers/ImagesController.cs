using ImagesStorage.Application.Interfaces;
using ImagesStorage.Application.Models;
using ImagesStorage.Application.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ImagesStorage.Controllers;

[ApiController]
[Route("[controller]")]
public class ImagesController : ControllerBase
{
    private readonly IImagesService _service;

    public ImagesController(IImagesService service)
    {
        _service = service;
    }

    [HttpGet]
    public ResultViewModel<IEnumerable<ImageViewModel>> All()
    {
        return _service.All();
    }

    [HttpPost]
    public ResultViewModel Create([FromBody] ImageDTO dto)
    {
        return _service.Set(dto);
    }
}
