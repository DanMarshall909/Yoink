using Microsoft.AspNetCore.Mvc;
using YoinkContracts.Results;
using YoinkServices;
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
    public async Task<ActionResult<ListFoldersResult>> GetAsync(string path = "/")
    {
        var listFoldersResult = await _fileSystemService
            .ListFolder(path, new FileFilter())
            .ConfigureAwait(false);
        
        return Ok(listFoldersResult);
    }
    
    
    [HttpGet(Name = "GetFileInfo")]
    public  ActionResult<GetFileInfoResult> GetFileInfo(string path)
    {
        var listFoldersResult = _fileSystemService
            .GetFileInfo(path);
        
        return Ok(listFoldersResult);
    }
}

