using Microsoft.AspNetCore.Mvc;

namespace WebApiAlumnoRegistro.Authentication
{
    public class ApikeyAttribute : ServiceFilterAttribute
    {
        public ApikeyAttribute() : base(typeof(ApiKeyAuthorizationFilter))
        {
            
        }
    }
}
