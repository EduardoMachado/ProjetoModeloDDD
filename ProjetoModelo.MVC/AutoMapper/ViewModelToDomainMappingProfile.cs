using AutoMapper;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModelo.MVC.ViewModels;

namespace ProjetoModelo.MVC.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override  string ProfileName
        {
            get { return "ViewModeltoDomainMappings"; }
        }

        public void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ProdutoViewModel, Produto>();
                cfg.CreateMap<ClienteViewModel, Cliente>();
            });
        }

        
    }
}