using CodingMiddleware.Services;
using System.IO;
using System.Text;

namespace CodingMiddleware.Middlewares
{
    public class CodingMiddleware
    {
        RequestDelegate _next;
        ICoder _coder;

        public CodingMiddleware(RequestDelegate next, ICoder coder)
        {
            _next = next;
            _coder = coder;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if(context.Request.ContentType != null && context.Request.ContentType.Contains("multipart/form-data"))
            {
                await GetData(context);
            }

            await _next.Invoke(context);

            static async Task GetData(HttpContext context)
            {
                IFormFileCollection files = context.Request.Form.Files;
                foreach (var file in files)
                {
                    Byte[] arData = new byte[file.Length];
                    using (var fileStream = file.OpenReadStream())
                    {
                        await fileStream.ReadAsync(arData, 0, (int)file.Length);
                    }
                }
            }
        }
    }
}
