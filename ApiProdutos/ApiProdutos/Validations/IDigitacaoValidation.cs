namespace ApiProdutos.Validations
{
    public interface IDigitacaoValidation<T>
    {
        string PrimeiraMaiuscula(string str);
        T? RemoverEspaco(T entity);
    }
}
