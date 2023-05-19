using AutoMapper;
using FluentValidation;
using Konyvtar_nyilvantarto.Contracts.LibraryMember;
using Konyvtar_nyilvantarto.Services.LibraryMembers.Model;
using Konyvtar_nyilvantarto.Services.LibraryMembers.Service;
using Konyvtar_nyilvantarto.Validators.LibraryMemberValidators.Models;
using LibaryRegister.Contracts.LibraryMember;
using Microsoft.AspNetCore.Mvc;

namespace Konyvtar_nyilvantarto.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LibraryMemberController : ControllerBase
    {
        private readonly IValidator<Guid> _guidValidator;
        private readonly IValidator<CreateLibraryMemberRequest> _validatorForCreateReq;
        private readonly IValidator<QueryParameterValidatorObject> _queryParamValidator;
        private readonly IValidator<UpdateLibraryMemberRequest> _updateValidator;

        private readonly IMapper _mapper;
        private readonly ILibaryMemberService _libaryMemberService;

        public LibraryMemberController(IValidator<CreateLibraryMemberRequest> validatorForCreateReq,
                                       IValidator<QueryParameterValidatorObject> queryParameterValidator,
                                       IValidator<Guid> guidValidator,
                                       IValidator<UpdateLibraryMemberRequest> updateValidator,
                                       IMapper mapper,
                                       ILibaryMemberService service)
        {
            _validatorForCreateReq = validatorForCreateReq;
            _queryParamValidator = queryParameterValidator;
            _guidValidator = guidValidator;
            _updateValidator = updateValidator;
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

            return result ? Ok() : BadRequest();  
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLibraryMember(Guid id)
        {
            var validationResult = _guidValidator.Validate(id);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var libraryMemberDto = await _libaryMemberService.GetLibraryMember(id);

            var result = _mapper.Map<LibraryMemberDto, LibraryMemberResponse>(libraryMemberDto);

            return result != null ? Ok(result) : NotFound();
        }

        [HttpGet]
        public IActionResult GetLibraryMembersByPage([FromQuery] int page, [FromQuery] int size)
        {
            var paramToValidate = new QueryParameterValidatorObject 
            {                 
                Page = page,
                Size = size
            };

            var validationResult = _queryParamValidator.Validate(paramToValidate);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var libraryMemberDtos = _libaryMemberService.GetLibraryMembersByPage(page, size);
            var result = _mapper.Map<IEnumerable<LibraryMemberDto>, IEnumerable<LibraryMemberResponse>>(libraryMemberDtos);

            return result != null ? Ok(libraryMemberDtos) : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLibraryMember(Guid id)
        {
            var validationResult = _guidValidator.Validate(id);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var result = await _libaryMemberService.DeleteLibraryMemberById(id);

            return result ? Ok() : BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateLibraryMember(UpdateLibraryMemberRequest request)
        {
            var validationResult = _updateValidator.Validate(request);
            if (!validationResult.IsValid)
                return BadRequest();

            var libraryMemberDto = _mapper.Map<UpdateLibraryMemberRequest, LibraryMemberDto>(request);

            var result = await _libaryMemberService.UpdateLibraryMember(libraryMemberDto);

            return result ? Ok() : BadRequest();
        }

        [HttpGet("/findByName/{name}")]
        public async Task<IActionResult> GetLibraryMember(string name)
        {
           
            var libraryMemberDto = await _libaryMemberService.GetLibraryMemberByName(name);

            var result = _mapper.Map<LibraryMemberDto, LibraryMemberResponse>(libraryMemberDto);

            return result != null ? Ok(result) : NotFound();
        }
    }
}
