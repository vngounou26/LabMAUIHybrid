using SharedLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Services
{
    public class SharedImageService:ISharedImageService
    {
        private readonly HttpClient _httpClient;

        public SharedImageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<MyImage>> GetAllImagesAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<MyImage>>("/images") ?? Enumerable.Empty<MyImage>();
        }
    }

    public interface ISharedImageService
    {
        Task<IEnumerable<MyImage>> GetAllImagesAsync();
    }
}
