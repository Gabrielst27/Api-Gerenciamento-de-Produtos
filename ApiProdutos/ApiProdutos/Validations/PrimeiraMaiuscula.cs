namespace ApiProdutos.Validations
{
    public class PrimeiraMaiuscula
    {
        public static string Corrigir(string str)
        {
            if (str is null) return null;

            char inicial = str[0];

            if (!inicial.Equals(inicial.ToString().ToUpper()))
            {
                string newStr = inicial.ToString().ToUpper() + str.Substring(1);

                return newStr;
            }

            return str;
        }
    }
}
