using ApiProdutos.DTOs;
using ApiProdutos.Extensions.DTOs;
using ApiProdutos.Models;
using ApiProdutos.Repositories;
using ApiProdutos.Validations;

namespace ApiProdutos.Business
{
    public class SubcategoriaBusiness
    {
        private readonly IUnitOfWork _uof;
        private readonly IDigitacaoValidation<Subcategoria> _digval;

        public SubcategoriaBusiness(IUnitOfWork uof, IDigitacaoValidation<Subcategoria> digval)
        {
            _uof = uof;
            _digval = digval;
        }

        public SubcategoriaDTO Get(long id)
        {
            return _uof.SubcategoriaRepository.Get(p => p.Id == id).ToDTO();
        }

        public IEnumerable<SubcategoriaDTO> GetAll()
        {
            return _uof.SubcategoriaRepository.GetAll().ToListDTO();
        }

        public SubcategoriaDTO Create(SubcategoriaDTO subcategoriaDto)
        {
            DateTime time = DateTime.Now;

            var subcategoria = subcategoriaDto.ToModel();

            Subcategoria sbc = _digval.RemoverEspaco(subcategoria);
            sbc.Nome = _digval.PrimeiraMaiuscula(sbc.Nome);

            _uof.SubcategoriaRepository.Create(sbc);
            _uof.Commit();

            return sbc.ToDTO();
        }

        public SubcategoriaDTO Update(SubcategoriaDTO subcategoriaDto)
        {
            var subcategoria = subcategoriaDto.ToModel();

            subcategoria.Nome = _digval.PrimeiraMaiuscula(subcategoria.Nome);

            _uof.SubcategoriaRepository.Update(subcategoria);
            _uof.Commit();

            return subcategoria.ToDTO();
        }

        public SubcategoriaDTO Delete(long id)
        {
            _uof.SubcategoriaRepository.Delete(p => p.Id == id);
            _uof.Commit();

            return _uof.SubcategoriaRepository.Get(p => p.Id == id).ToDTO();
        }
    }
}
