using HwStore.Application.DTOs.Basket;

namespace HwStore.Api.DTOs
{
    public class UserDto
    {
        public string Email { get; set; }
        public string Token { get; set; }
        public BasketDto_Base? Basket { get; set; }
        public string Image { get; set; }
    }
}
