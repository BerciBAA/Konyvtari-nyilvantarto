using Konyvtar_nyilvantarto.Contracts.LibraryMember;
using System.Net.Http.Json;

namespace Konyvtar_nyilvantarto.Blazor.Services
{
    public class LibraryMemberService : ILibraryMemberService
    {

        private readonly HttpClient _httpClient;
        public LibraryMemberService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<LibraryMemberResponse?> GetLibraryMemberByNameAsync(string name)
        {
            return await _httpClient.GetFromJsonAsync<LibraryMemberResponse?>($"/findByName/{name}");
        }
    }
}
