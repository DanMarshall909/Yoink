using Microsoft.AspNetCore.Mvc;
using YoinkContracts.Results;
using YoinkServices.Interfaces;

namespace YoinkApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FolderController : ControllerBase
{
    private readonly IFileSystemService _fileSystemService;
    private readonly ILogger<FolderController> _logger;

    public FolderController(ILogger<FolderController> logger, IFileSystemService fileSystemService)
    {
        _logger = logger;
        _fileSystemService = fileSystemService;
    }

    [HttpGet(Name = "ListFolder")]
    public async Task<ActionResult<ListFoldersResult>> GetAsync()
    {
        return Ok(await _fileSystemService.ListFolderAsync());
    }
}