using AutoMapper;
using ProjetoModelo.MVC.ViewModels;
using ProjetoModeloDDD.Domain.Entities;

namespace ProjetoModelo.MVC.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {

        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        public void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Produto,ProdutoViewModel>();
                cfg.CreateMap<Cliente,ClienteViewModel>();
            });
        }
    }
}