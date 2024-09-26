﻿using CloudStorage_Rocketseat.Domain.Entities;
using CloudStorage_Rocketseat.Domain.Storage;
using FileTypeChecker.Extensions;
using FileTypeChecker.Types;
using Microsoft.AspNetCore.Http;

namespace CloudStorage.Application.UseCases.Users.UploadProfilePic;
public class UploadProfilePicUseCase
{
    private readonly IStorageService _storageService;
    public UploadProfilePicUseCase(IStorageService storageService)
    {
        _storageService = storageService;
    }

    public void Execute(IFormFile file)
    {
        var fileStream = file.OpenReadStream();

        var isImage = fileStream.Is<JointPhotographicExpertsGroup>();

        if (!isImage)
            throw new Exception("The file is not an image.");

        var user = GetFromDatabase();

        _storageService.Upload(file, user);
    }

    private User GetFromDatabase()
    {
        return new User
        {
            Id = 1,
            Name = "Nathan",
            Email = "nathanmarques.silva@gmail.com"
        };
    }
}
