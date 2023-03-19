namespace CodingMiddleware.Middlewares
{
    public static class MiddlewareExtensions
    {
        public static void UseCoding(this IApplicationBuilder app)
        {
            app.UseMiddleware<CodingMiddleware>();
        }
    }
}
