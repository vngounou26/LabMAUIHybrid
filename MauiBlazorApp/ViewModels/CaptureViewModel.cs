using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiBlazorApp.Models;
using MauiBlazorApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiBlazorApp.ViewModels
{
    public partial class CaptureViewModel:ObservableObject
    {
        private IImageService _imageService;

        public CaptureViewModel(IImageService imageService)
        {
            _imageService = imageService;
        }

        [RelayCommand]
        public async Task SaveImage(string imageData)
        {
            await _imageService.AddImageAsync(new MyImage { ImageData = imageData });
        }
    }
}
