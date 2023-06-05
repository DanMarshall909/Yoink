using Microsoft.AspNetCore.Mvc;
using YoinkContracts.Responses;
using YoinkServices;
using YoinkServices.Interfaces;

namespace YoinkApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FolderController : ControllerBase
{
    private readonly IFileSystemService _fileSystemService;
    private readonly ILogger<FolderController> _logger;

    public FolderController(ILogger<FolderController> logger, IFileSystemService fileSystemService)
    {
        _logger = logger;
        _fileSystemService = fileSystemService;
    }

    [HttpGet("ListFolder")]
    public async Task<ActionResult<ListFoldersResponse>> GetAsync(string path = "/")
    {
        var listFoldersResult = await _fileSystemService
            .ListFolder(path, new FileFilter())
            .ConfigureAwait(false);
        
        return Ok(listFoldersResult);
    }
    
    
    [HttpGet("GetFileInfo")]
    public  ActionResult<GetFileInfoResponse> GetFileInfo(string path)
    {
        var listFoldersResult = _fileSystemService
            .GetFileInfo(path);
        
        return Ok(listFoldersResult);
    }
}

