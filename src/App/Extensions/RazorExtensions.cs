using Microsoft.AspNetCore.Mvc.Razor;

namespace App.Extensions
{
    public static class RazorExtensions
    {
        //metodo formatadocumento - Estou estendendo a razorpage(view) ||| pasando o tipo da pessoa e o documento
        public static string FormataDocumento(this RazorPage page, int tipoPessoa, string documento)
        {
            //Se tipo=1 - converte para int64 e depois para string
            return tipoPessoa == 1 ? Convert.ToUInt64(documento).ToString(@"000\.000\.000\-00") : Convert.ToUInt64(documento).ToString(@"00\.000\.000\/0000\-00");
        }

    }
}
