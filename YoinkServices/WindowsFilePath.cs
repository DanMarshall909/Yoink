﻿using Path = YoinkContracts.Responses.Path;

namespace YoinkServices;

public record WindowsFilePath : YoinkContracts.Responses.Path
{
    private readonly string _path = string.Empty;

    public override string FullName
    {
        get => _path;
        init
        {
            var (isValid, path) = ParsePath(value);
            if (isValid)
                _path = value;
            else throw new ArgumentException($"Invalid path: {value}");
        }
    }

    public override (bool isValid, string path) ParsePath(string windowsPath)
    {
        try
        {
            FileInfo fi = new(windowsPath);
            return (true, fi.FullName);
        }
        catch (Exception)
        {
            return (false, $"Invalid path '{windowsPath}'");
        }
    }
}