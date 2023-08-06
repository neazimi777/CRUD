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
        CreateMap<CreateCustomerDto, Domain.Customer>()
           .ForMember(x => x.DateOfBirth, opt => opt.Ignore())
            .ReverseMap();

        CreateMap<UpdateCustomerDto, Domain.Customer>()
             .ForMember(x => x.DateOfBirth, opt => opt.Ignore())
          .ReverseMap();

        CreateMap<GetCustomerDto, Domain.Customer>()
            .ForMember(x => x.DateOfBirth, opt => opt.Ignore())
        .ReverseMap();

        CreateMap<CreateCustomerEventDto, Domain.CustomerEvent>()
             .ForMember(x => x.DateOfBirth, opt => opt.Ignore())
            .ReverseMap();

    }


}