using Konyvtar_nyilvantarto.Services.BorrowingData.Model;

namespace Konyvtar_nyilvantarto.Services.BorrowingData.Repository
{
    public interface IBorrowingDataRepository
    {
        Task<BorrowingDataEntity> Get(Guid id);

        Task<IEnumerable<BorrowingDataEntity>> GetAll();

        Task<BorrowingDataEntity> Insert(BorrowingDataEntity borrowingData);

        Task<BorrowingDataEntity> Update(Guid id, BorrowingDataEntity borrowingData);

        Task Delete(BorrowingDataEntity borrowingData);
    }
}
