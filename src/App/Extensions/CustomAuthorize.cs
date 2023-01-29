using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace App.Extensions
{
    public class CustomAuthorization
    {
        //classe CustomAuthorization fornece um metodo estatico -
        //                  Ele valida as claims
        public static bool ValidarClaimsUsuario(HttpContext context, string claimName, string claimValue)
        {
            //retorna se o usuário possui autenticação e se possui a claim
            return context.User.Identity.IsAuthenticated &&
                   context.User.Claims.Any(c => c.Type == claimName && c.Value.Contains(claimValue));
        }

    }

    //atributo que iremos usar herdando do tipo de filtro do atributo
    public class ClaimsAuthorizeAttribute : TypeFilterAttribute
    {
        //uso do requisto claim filter
                                                                                          //Declaração do filtro
        public ClaimsAuthorizeAttribute(string claimName, string claimValue) : base(typeof(RequisitoClaimFilter))
        {
            Arguments = new object[] { new Claim(claimName, claimValue) };
        }
    }

    //classe acima - Criando um atributo "ClaimsAuthorizeAttribute" que vai utilizar um filtro "TypeFilterAttribute"
    public class RequisitoClaimFilter : IAuthorizationFilter
    {
        private readonly Claim _claim;

                                    //recebo claim como parametro
        public RequisitoClaimFilter(Claim claim)
        {
            _claim = claim;
        }

        //faz validação para ver se esta autenticado
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            //se ele não esta autenticado envio ele para pagina de atentiação 
            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { area = "Identity", page = "/Account/Login", ReturnUrl = context.HttpContext.Request.Path.ToString() }));
                return;
            }
            //caso ele esteja verifico se ele possue os tipos das claims requeridas e senão retorno um 403
            if (!CustomAuthorization.ValidarClaimsUsuario(context.HttpContext, _claim.Type, _claim.Value))
            {
                context.Result = new StatusCodeResult(403);
            }
        }
    }
}
