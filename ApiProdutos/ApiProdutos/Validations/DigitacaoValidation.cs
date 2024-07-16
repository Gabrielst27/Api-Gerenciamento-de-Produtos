namespace ApiProdutos.Validations
{
    public class DigitacaoValidation : IDigitacaoValidation
    {
        public string PrimeiraMaiuscula(string str)
        {
            if (str is not null)
            {
                char inicial = str[0];

                if (!inicial.Equals(inicial.ToString().ToUpper()))
                {
                    string newStr = inicial.ToString().ToUpper() + str.Substring(1);

                    return newStr;
                }
            }

            return str;
        }
    }
}
