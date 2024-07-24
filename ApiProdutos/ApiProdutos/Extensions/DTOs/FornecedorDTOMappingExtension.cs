using ApiProdutos.DTOs;
using ApiProdutos.Models;

namespace ApiProdutos.Extensions.DTOs
{
    public static class FornecedorDTOMappingExtension
    {
        public static FornecedorDTO? ToDTO(this Fornecedor fornecedor)
        {
            if (fornecedor is null) return null;

            return new FornecedorDTO()
            {
                Id = fornecedor.Id,
                Bairro = fornecedor.Bairro,
                Cep = fornecedor.Cep,
                Cidade = fornecedor.Cidade,
                Cnpj = fornecedor.Cnpj,
                Codinterno = fornecedor.Codinterno,
                Complemento = fornecedor.Complemento,
                Contratos = fornecedor.Contratos,
                Email = fornecedor.Email,
                Fantasia = fornecedor.Fantasia,
                Logradouro = fornecedor.Logradouro,
                Numero = fornecedor.Numero,
                Pais = fornecedor.Pais,
                RazaoSocial = fornecedor.RazaoSocial,
                Status = fornecedor.Status,
                Telefone1 = fornecedor.Telefone1,
                Telefone2 = fornecedor.Telefone2,
                Telefone3 = fornecedor.Telefone3,
                Uf = fornecedor.Uf
            };
        }

        public static Fornecedor? ToModel(this FornecedorDTO fornecedorDto)
        {
            if (fornecedorDto is null) return null;

            return new Fornecedor()
            {
                Id = fornecedorDto.Id,
                Bairro = fornecedorDto.Bairro,
                Cep = fornecedorDto.Cep,
                Cidade = fornecedorDto.Cidade,
                Cnpj = fornecedorDto.Cnpj,
                Codinterno = fornecedorDto.Codinterno,
                Complemento = fornecedorDto.Complemento,
                Contratos = fornecedorDto.Contratos,
                Email = fornecedorDto.Email,
                Fantasia = fornecedorDto.Fantasia,
                Logradouro = fornecedorDto.Logradouro,
                Numero = fornecedorDto.Numero,
                Pais = fornecedorDto.Pais,
                RazaoSocial = fornecedorDto.RazaoSocial,
                Status = fornecedorDto.Status,
                Telefone1 = fornecedorDto.Telefone1,
                Telefone2 = fornecedorDto.Telefone2,
                Telefone3 = fornecedorDto.Telefone3,
                Uf = fornecedorDto.Uf
            };
        }

        public static IEnumerable<FornecedorDTO>? ToListDTO(this IEnumerable<Fornecedor> fornecedores)
        {
            if (fornecedores is null || !fornecedores.Any())
            {
                return new List<FornecedorDTO>();
            }

            return fornecedores.Select(fornecedor => new FornecedorDTO
            {
                Id = fornecedor.Id,
                Bairro = fornecedor.Bairro,
                Cep = fornecedor.Cep,
                Cidade = fornecedor.Cidade,
                Cnpj = fornecedor.Cnpj,
                Codinterno = fornecedor.Codinterno,
                Complemento = fornecedor.Complemento,
                Contratos = fornecedor.Contratos,
                Email = fornecedor.Email,
                Fantasia = fornecedor.Fantasia,
                Logradouro = fornecedor.Logradouro,
                Numero = fornecedor.Numero,
                Pais = fornecedor.Pais,
                RazaoSocial = fornecedor.RazaoSocial,
                Status = fornecedor.Status,
                Telefone1 = fornecedor.Telefone1,
                Telefone2 = fornecedor.Telefone2,
                Telefone3 = fornecedor.Telefone3,
                Uf = fornecedor.Uf
            });
        }
    }
}
