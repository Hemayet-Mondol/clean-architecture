using AutoMapper;
using FirstApp.Model;
using FirstApp.Service.Repository.ViewModel;

namespace FirstApp.Core.Mapper;

public class CommonMapper:Profile
{
    public CommonMapper() {

         CreateMap<VMProduct,Product>().ReverseMap();
        CreateMap<VMEmployee,Employee>().ReverseMap();
        CreateMap<VMDepartment,Department>().ReverseMap();
        CreateMap<VMCountry,Country>().ReverseMap();
        CreateMap<VMState,State>().ReverseMap();
        CreateMap<VMCity,City>().ReverseMap();
    }
}
