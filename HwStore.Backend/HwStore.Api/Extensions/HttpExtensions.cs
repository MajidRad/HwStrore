using System.Text.Json;


namespace HwStore.Api.Extensions
{
    public static class HttpExtensions
    {
        public static void AddPaginationHeader(this HttpResponse response,
            int currentPage,
            int itemPerPage,
            int totalItems,
            int totalPages)
        {
            var paginationHeader = new
            {
                currentPage,
                itemPerPage,
                totalItems,
                totalPages
            };
            response.Headers.Add("Pagination", JsonSerializer.Serialize(paginationHeader));
        }
    }
}
