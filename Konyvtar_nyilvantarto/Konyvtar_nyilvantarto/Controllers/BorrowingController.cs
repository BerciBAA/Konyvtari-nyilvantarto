using AutoMapper;
using FluentValidation;
using Konyvtar_nyilvantarto.Contracts.BorrowingData;
using Konyvtar_nyilvantarto.Services.BorrowingData.Model;
using Konyvtar_nyilvantarto.Services.BorrowingData.Service;
using Microsoft.AspNetCore.Mvc;

namespace Konyvtar_nyilvantarto.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BorrowingController : ControllerBase
    {
        private readonly IBorrowingDataService _borrowingDataService;
        private readonly IMapper _mapper;
        private readonly IValidator<BorrowingRequest> _validator;
        public BorrowingController(IBorrowingDataService borrowingDataService ,IMapper mapper, IValidator<BorrowingRequest> validator)
        {
            _borrowingDataService = borrowingDataService;
            _mapper = mapper;
            _validator = validator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BorrowingResponse>> Get(Guid id)
        {
            var borrowingData = await _borrowingDataService.Get(id);
            if (borrowingData is null) {
                return NotFound();
            }
            var result = _mapper.Map<BorrowingDataDto, BorrowingResponse>(borrowingData);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> InsertPost(BorrowingRequest borrowingData)
        {
            var validationResult = _validator.Validate(borrowingData);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var borrowingDataDto = _mapper.Map<BorrowingRequest, BorrowingDataDto>(borrowingData);
            var insertedborrowingData = await _borrowingDataService.Insert(borrowingDataDto);

            if (insertedborrowingData is null)
            {
                return Conflict();
            }
            return Created($"/borrowingdata/{insertedborrowingData.BorrowingId}", insertedborrowingData);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BorrowingResponse>>> Get()
        {

            var borrowingData = await _borrowingDataService.GetAll();
            var result = _mapper.Map<IEnumerable<BorrowingDataDto>, IEnumerable<BorrowingResponse>>(borrowingData);
            return Ok(result);
        }

        [HttpPut()]
        public async Task<ActionResult<BorrowingResponse>> UpdatePut(Guid id, BorrowingRequest borrowingData) {

            var borrowingDataDto = _mapper.Map<BorrowingRequest, BorrowingDataDto>(borrowingData);
            var result = await _borrowingDataService.Update(id, borrowingDataDto);
            if (result is null) {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id) {
            var isDeleted = await _borrowingDataService.Delete(id);
            if (!isDeleted) {
                return NotFound();
            }
            return Ok();
        }
    }
}
