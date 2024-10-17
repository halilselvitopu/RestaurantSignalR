using SignalRWebUI.Dtos.ProductDtos;

namespace SignalRWebUI.Dtos.BasketDtos
{
    public class ResultBasketDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public ResultProductDto Product { get; set; }
        public decimal Price { get; set; }
        public int ProductCount { get; set; }
        public decimal TotalPrice { get; set; }
        public int TableId { get; set; }
    }
}
