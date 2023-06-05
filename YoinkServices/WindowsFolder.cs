using YoinkContracts.Models;
using YoinkContracts.Responses;

namespace YoinkServices;

public record WindowsFolder : Folder
{
    public WindowsFolder(WindowsFolderPath path, WindowsFolder? parent) : base(path, parent)
    {
    }
}