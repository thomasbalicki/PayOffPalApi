using AutoMapper;
using PayOffPalApi.Data;
using PayOffPalApi.Models.Debt;
using PayOffPalApi.Models.DebtCategory;

namespace PayOffPalApi.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<DebtCategory, CreateDebtCategoryDto>().ReverseMap();
            CreateMap<DebtCategory, GetDebtCategoryDto>().ReverseMap();
            CreateMap<DebtCategory, DebtCategoryDto>().ReverseMap();
            CreateMap<DebtCategory, UpdateDebtCategoryDto>().ReverseMap();
            CreateMap<Debt, DebtDto>().ReverseMap();
        }
    }
}
