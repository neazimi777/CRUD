using AutoMapper;
using Mc2.CrudTest.Dto.Customer;
using Mc2.CrudTest.Dto.EventCustomer;
using System.Text;
using XSystem.Security.Cryptography;

namespace Mc2.CrudTest.DomainService;

/// <summary>
///     configuration mapper class. you may make it public later when needed e.g. for unit testing.
/// </summary>
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateCustomerDto, Domain.CustomerEvent>()
            .ReverseMap();

        CreateMap<UpdateCustomerDto, Domain.CustomerEvent>()
          .ReverseMap();

        CreateMap<GetCustomerDto, Domain.CustomerEvent>()
        .ReverseMap();

    }


}