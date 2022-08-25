using AutoMapper;
using StoreProcedural.Dto.ContactDto;
using StoreProcedural.Models;

namespace StoreProcedural
{
    public class Mapper :Profile
    {
        public Mapper()
        {
            CreateMap<Contacts, GetContactDto>();
        }
    }
}
