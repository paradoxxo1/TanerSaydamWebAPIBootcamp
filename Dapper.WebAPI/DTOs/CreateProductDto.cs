namespace Dapper.WebAPI.DTOs
{
    public sealed record CreateProductDto(
        string Name,
        decimal Price);
}
