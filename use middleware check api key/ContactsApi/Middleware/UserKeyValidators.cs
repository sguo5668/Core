using ContactsApi.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Threading.Tasks;

namespace ContactsApi.Middleware
{
    public class UserKeyValidatorsMiddleware
    {

		private const string APIKeyToCheck = "12345678";

        private readonly RequestDelegate _next;

 

		public UserKeyValidatorsMiddleware(RequestDelegate next )
		{
            _next = next;
	 

		}

        public async Task Invoke(HttpContext context)
        {
			bool validKey = false;

			var checkApiKeyExists = context.Request.Headers.ContainsKey("APIKey");

			if (checkApiKeyExists)
			{

				if ( context.Request.Headers["APIKey"].Equals(APIKeyToCheck))
				{
					validKey = true;
				}
			}


			if (!validKey)
			{
				context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
				await context.Response.WriteAsync("InValid API Key");

			}

			else
			{

				await _next.Invoke(context);
			}

        }

    }

    #region ExtensionMethod
    public static class UserKeyValidatorsExtension
    {
        public static IApplicationBuilder ApplyUserKeyValidation(this IApplicationBuilder app)
        {
            app.UseMiddleware<UserKeyValidatorsMiddleware>();
            return app;
        }
    }




    #endregion
}
