using System.Text.RegularExpressions;

namespace ApiProdutos.Validations
{
    public class DigitacaoValidation<T> : IDigitacaoValidation<T> where T : class
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

        public T? RemoverEspaco(T entity)
        {
            var atributos = typeof(T).GetProperties();

            foreach(var atributo in atributos)
            {
                if (atributo.PropertyType == typeof(string))
                { 
                    var valor = (string?)atributo.GetValue(entity);
                    
                    if (!string.IsNullOrEmpty(valor))
                    {
                        valor = valor.TrimStart();
                        atributo.SetValue(entity, valor);
                    }
                }
            }

            return entity;
        }
    }
}
