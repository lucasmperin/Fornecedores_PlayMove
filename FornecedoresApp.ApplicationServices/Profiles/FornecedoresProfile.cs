using AutoMapper;
using FornecedoresApp.ApplicationModels.Entities;
using FornecedoresApp.DomainModels;

namespace FornecedoresApp.ApplicationServices.Profiles
{
    public class FornecedoresProfile : Profile
    {
        public FornecedoresProfile()
        {
            CreateMap<FornecedoresRequest, Fornecedor>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember is not null and not (object)"string"));
            CreateMap<Fornecedor, FornecedoresResponse>();
        }
    }
}
