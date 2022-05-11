namespace AdminTemplate.Dtos
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public int CategoryId
        {
            get; set;
        }
        public string? CategoryName
        {
            get; set;
        }
    }
}