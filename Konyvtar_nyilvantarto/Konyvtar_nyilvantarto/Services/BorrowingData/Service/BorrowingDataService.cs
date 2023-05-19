using AutoMapper;
using Konyvtar_nyilvantarto.Services.Book.Model;
using Konyvtar_nyilvantarto.Services.BorrowingData.Model;
using Konyvtar_nyilvantarto.Services.BorrowingData.Repository;
using Konyvtar_nyilvantarto.Services.LibraryMembers.Repository;
using LibaryRegister.Contracts.Book;

namespace Konyvtar_nyilvantarto.Services.BorrowingData.Service
{
    public class BorrowingDataService : IBorrowingDataService
    {
        private readonly IBorrowingDataRepository _borrowingDataRepository;
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;
        private readonly ILibraryMemberRepository _libraryMemberRepository;

        public BorrowingDataService(IBorrowingDataRepository borrowingDataRepository,
                                    IMapper mapper,
                                    IBookRepository bookRepository,
                                    ILibraryMemberRepository libraryMemberRepository)
        {
            _bookRepository = bookRepository;
            _libraryMemberRepository = libraryMemberRepository;
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
            var book = await _bookRepository.Get(borrowingData.BookId);
            var libraryMember = await _libraryMemberRepository.GetLibraryMemberById(borrowingData.LibraryMemberId);
            var borrowingDataEntity = _mapper.Map<BorrowingDataDto, BorrowingDataEntity>(borrowingData);
            if (book is null && libraryMember is null) {
                return null;
            }
            borrowingDataEntity.Book = book;
            borrowingDataEntity.LibraryMembers = libraryMember;
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

        public async Task<BorrowingDataDto> GetBorrowingByBookId(Guid bookId)
        {
            var existedBorrowingDatas = await _borrowingDataRepository.GetAll();
            var result = existedBorrowingDatas.FirstOrDefault(x => x.BorrowingDataBookEntityFK == bookId);
            return _mapper.Map<BorrowingDataEntity, BorrowingDataDto>(result);
        }

        public async Task<IEnumerable<BorrowingDataDto>> GetBorrowingByMemberId(Guid memberId)
        {
            var existedBorrowingDatas = await _borrowingDataRepository.GetAll();
            var result = existedBorrowingDatas.Where(x => x.BorrowingDataLibraryMembersFK == memberId);
            return _mapper.Map< IEnumerable<BorrowingDataEntity>, IEnumerable<BorrowingDataDto>>(result);
        }
    }
}
