using System.Text.Json;

namespace HwStore.Api.Extensions;

public static class HttpExtensions
{
    public static void AddPaginationHeader(this HttpResponse response,
        int currentPage,
        int totalPages,
        int itemsPerPage,
        int totalItems
        )
    {
        var paginationHeader = new
        {
            currentPage,
            itemsPerPage,
            totalItems,
            totalPages
        };
        var options = new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

        response.Headers.Add("Pagination", JsonSerializer.Serialize(paginationHeader, options));
        response.Headers.Add("Access-Control-Expose-Headers", "Pagination");
    }

}
