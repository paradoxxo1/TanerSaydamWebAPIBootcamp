﻿namespace eCommerce.DTOs
{
    public sealed record RegisterDto(
        string FirstName,
        string LastName,
        string UserName,
        string Password);

}
