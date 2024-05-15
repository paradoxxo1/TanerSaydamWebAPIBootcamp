using AutoMapper;
using Project.Bll.DTOClasses;
using Project.Entities.Models;

namespace Project.Bll.MapperProfiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDTO>().ForMember(target => target.Aciklama, org => org.MapFrom(x => x.Description)).ReverseMap();
        }
    }
}
