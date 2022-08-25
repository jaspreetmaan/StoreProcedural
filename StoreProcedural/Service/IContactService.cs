using StoreProcedural.Dto.ContactDto;
using StoreProcedural.Models;

namespace StoreProcedural.Service
{
    public interface IContactService
    {
        ServiceResponse<GetContactDto> AddData(GetContactDto contact);
        ServiceResponse<List<Contacts>> GetContacts();
        List<Contacts> DeleteContact(int id);
        int UpdateContact(Contacts contact);
    }
}
