
using SharedLibrary.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MauiBlazorApp.Services
{
    internal class ImageService(HttpClient httpClient):IImageService
    {
        private readonly HttpClient _httpClient= httpClient;

        public async Task AddImageAsync(MyImage image)
        {
            if(image is not null)
            {
                var responce =await _httpClient.PostAsJsonAsync("/images",image);
                if(!responce.IsSuccessStatusCode)
                {
                    Debug.WriteLine("Image not added");
                    throw new Exception("Image not added");
                }
            }
        }
    }

    public interface IImageService
    {
        Task AddImageAsync( MyImage image);
    }
}
