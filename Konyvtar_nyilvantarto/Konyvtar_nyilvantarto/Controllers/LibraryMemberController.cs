using AutoMapper;
using FluentValidation;
using Konyvtar_nyilvantarto.Contracts.LibraryMember;
using Konyvtar_nyilvantarto.Services.LibraryMembers.Model;
using Microsoft.AspNetCore.Mvc;

namespace Konyvtar_nyilvantarto.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LibraryMemberController : ControllerBase
    {
        private IValidator<CreateLibraryMemberRequest> _validatorForCreateReq;
        private IMapper _mapper;

        public LibraryMemberController(IValidator<CreateLibraryMemberRequest> validator,
                                       IMapper mapper)
        {
            _validatorForCreateReq = validator;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddLibraryMember([FromBody] CreateLibraryMemberRequest request)
        {
            var validationResult = _validatorForCreateReq.Validate(request);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var libraryMemberDto = _mapper.Map<CreateLibraryMemberRequest, LibraryMemberDto>(request);


            return Ok();
        }
    }
}
