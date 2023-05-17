using Konyvtar_nyilvantarto.Services.BorrowingData.Model;

namespace Konyvtar_nyilvantarto.Services.BorrowingData.Service
{
    public interface IBorrowingDataService
    {
        Task<BorrowingDataDto> Get(Guid id);

        Task<IEnumerable<BorrowingDataDto>> GetAll();

        Task<BorrowingDataDto> Insert(BorrowingDataDto borrowingData);

        Task<BorrowingDataDto> Update(Guid id, BorrowingDataDto borrowingData);

        Task<bool> Delete(Guid id);
    }
}
