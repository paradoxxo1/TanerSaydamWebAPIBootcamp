using Microsoft.AspNetCore.Authorization;

namespace MinimalAPI2.WebAPI.Endpoints
{
    public static class TodoEndpoints
    {
        public static void UseTodoEndpoint(this IEndpointRouteBuilder app)
        {
            app.MapGet("/get", () => "This is a get method").WithTags("todos");
            app.MapPost("/post", () => "This is a post method").WithTags("todos");
            app.MapPut("/put", () => "This is a put method").WithTags("todos");
            app.MapDelete("/delete", () => "This is a delete method").WithTags("todos");

            var handler = () => "This is a handler";
            app.MapGet("/get2", handler).WithTags("todos");

            app.MapGet("/get3", () =>
            {
                //operations
                return "This is extend method";
            }).WithTags("todos");


        }
        public static void UseTodo2Endpoint(this IEndpointRouteBuilder app)
        {
            app.MapGet("/get4", async (CancellationToken cancellationToken) =>
            {
                await Task.CompletedTask;
                return "This is a async method";
            }).WithTags("todos2");

            app.MapGet("/get5", () =>
            {
                return Results.Ok(new { Message = "this is a results ok method" });
            }).WithTags("todos2");

            app.MapGet("/get6", (IConfiguration configuration, int a) =>
            {
                return "This isDependency Injection request";
            }).WithTags("todos2");

            app.MapGet("/get7",
                [Authorize] () =>
                {
                    return "This is adding attribute method";
                }).WithTags("todos2");
        }
    }
}
