using AutoMapper;
using Konyvtar_nyilvantarto.Services.BorrowingData.Model;
using Konyvtar_nyilvantarto.Services.BorrowingData.Repository;

namespace Konyvtar_nyilvantarto.Services.BorrowingData.Service
{
    public class BorrowingDataService : IBorrowingDataService
    {
        private readonly IBorrowingDataRepository _borrowingDataRepository;
        private readonly IMapper _mapper;

        public BorrowingDataService(IBorrowingDataRepository borrowingDataRepository, IMapper mapper)
        {
            _borrowingDataRepository = borrowingDataRepository;
            _mapper = mapper;
        }

        public async Task<BorrowingDataDto> Get(Guid id)
        {
            var existedBorrowingData = await _borrowingDataRepository.Get(id);
            return _mapper.Map<BorrowingDataEntity, BorrowingDataDto>(existedBorrowingData);
        }

        public async Task<IEnumerable<BorrowingDataDto>> GetAll()
        {
            var result = await _borrowingDataRepository.GetAll();
            return _mapper.Map<IEnumerable<BorrowingDataEntity>, IEnumerable<BorrowingDataDto>>(result);
        }

        public async Task<BorrowingDataDto> Insert(BorrowingDataDto borrowingData)
        {
            var borrowingDataEntity = _mapper.Map<BorrowingDataDto, BorrowingDataEntity>(borrowingData);
            var result = await _borrowingDataRepository.Insert(borrowingDataEntity);
            return _mapper.Map<BorrowingDataEntity, BorrowingDataDto>(result);
        }

        public async Task<BorrowingDataDto> Update(Guid id, BorrowingDataDto borrowingData)
        {
            var borrowingDataEntity = _mapper.Map<BorrowingDataDto, BorrowingDataEntity>(borrowingData);
            var existedBorrowingData = await _borrowingDataRepository.Get(id);
            if (existedBorrowingData is null) { 
                return _mapper.Map<BorrowingDataEntity, BorrowingDataDto>(existedBorrowingData);
            }

            var result =  await _borrowingDataRepository.Update(id, borrowingDataEntity);
            return _mapper.Map<BorrowingDataEntity, BorrowingDataDto>(result);
        }

        public async Task<bool> Delete(Guid id)
        {
            var result = await _borrowingDataRepository.Get(id);
            if(result is null)
            {
                return false;

            }
            await _borrowingDataRepository.Delete(result);
            return true;
        }

    }
}
