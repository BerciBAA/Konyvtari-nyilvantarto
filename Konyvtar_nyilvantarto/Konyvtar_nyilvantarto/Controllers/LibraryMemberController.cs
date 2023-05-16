using AutoMapper;
using FluentValidation;
using Konyvtar_nyilvantarto.Contracts.LibraryMember;
using Konyvtar_nyilvantarto.Services.LibraryMembers.Model;
using Konyvtar_nyilvantarto.Services.LibraryMembers.Repository;
using Konyvtar_nyilvantarto.Services.LibraryMembers.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Konyvtar_nyilvantarto.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LibraryMemberController : ControllerBase
    {
        private readonly IValidator<CreateLibraryMemberRequest> _validatorForCreateReq;
        private readonly IMapper _mapper;
        private readonly ILibaryMemberService _libaryMemberService;

        public LibraryMemberController(IValidator<CreateLibraryMemberRequest> validator,
                                       IMapper mapper,
                                       ILibaryMemberService service)
        {
            _validatorForCreateReq = validator;
            _mapper = mapper;
            _libaryMemberService = service;
        }

        [HttpPost]
        public async Task<IActionResult> AddLibraryMember([FromBody] CreateLibraryMemberRequest request)
        {
            var validationResult = _validatorForCreateReq.Validate(request);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var libraryMemberDto = _mapper.Map<CreateLibraryMemberRequest, LibraryMemberDto>(request);

            var result = await _libaryMemberService.AddLibraryMember(libraryMemberDto);

            return result == true ? Ok() : BadRequest();  
        }
    }
}
