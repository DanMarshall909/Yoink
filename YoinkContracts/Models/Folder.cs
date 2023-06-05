using Path = YoinkContracts.Responses.Path;

namespace YoinkContracts.Models;

public record Folder(Path Path, Folder? Parent);