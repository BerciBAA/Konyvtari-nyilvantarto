using Konyvtar_nyilvantarto.Services.BorrowingData.Model;

namespace Konyvtar_nyilvantarto.Services.BorrowingData.Service
{
    public interface IBorrowingDataService
    {
        Task<BorrowingDataDto> Get(Guid id);
        Task<BorrowingDataDto> GetBorrowingByBookId(Guid bookId);
        Task<IEnumerable<BorrowingDataDto>> GetBorrowingByMemberId(Guid memberId);

        Task<IEnumerable<BorrowingDataDto>> GetAll();

        Task<BorrowingDataDto> Insert(BorrowingDataDto borrowingData);

        Task<BorrowingDataDto> Update(Guid id, BorrowingDataDto borrowingData);

        Task<bool> Delete(Guid id);
    }
}
