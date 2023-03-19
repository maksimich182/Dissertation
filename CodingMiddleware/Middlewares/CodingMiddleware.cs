using CodingMiddleware.Services;
using CodingMiddleware.Support;
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
                byte[] data = await GetData(context);
                ProbabilityMatrix probMartix = new ProbabilityMatrix(256);
                
            }

            await _next.Invoke(context);

            static async Task<byte[]> GetData(HttpContext context)
            {
                Byte[] arData = null!;
                IFormFileCollection files = context.Request.Form.Files;
                foreach (var file in files)
                {
                    arData = new byte[file.Length];
                    using (var fileStream = file.OpenReadStream())
                    {
                        await fileStream.ReadAsync(arData, 0, (int)file.Length);
                    }
                }
                return arData;
            }
        }
    }
}
