namespace eCommerce.DTOs
{
    public sealed record UpdateProductDto(
        Guid Id,
        string Name,
        decimal Price
        );

}
