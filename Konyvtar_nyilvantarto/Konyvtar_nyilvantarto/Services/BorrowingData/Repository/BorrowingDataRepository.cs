using Konyvtar_nyilvantarto.Contexts;
using Konyvtar_nyilvantarto.Services.BorrowingData.Model;
using Microsoft.EntityFrameworkCore;

namespace Konyvtar_nyilvantarto.Services.BorrowingData.Repository
{
    public class BorrowingDataRepository : IBorrowingDataRepository
    {
        private LibraryContext _libraryContext;
        public BorrowingDataRepository(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        public async Task<BorrowingDataEntity> Get(Guid id)
        {

            return await _libraryContext.BorrowingData.FindAsync(id);
        }

        public async Task<IEnumerable<BorrowingDataEntity>> GetAll()
        {
            return await _libraryContext.BorrowingData.ToListAsync();
        }

        public async Task<BorrowingDataEntity> Insert(BorrowingDataEntity borrowingData)
        {
            _libraryContext.BorrowingData.Add(borrowingData);
            await _libraryContext.SaveChangesAsync();
            return await _libraryContext.BorrowingData.FindAsync(borrowingData.BorrowingId);
        }

        public async Task<BorrowingDataEntity> Update(Guid id, BorrowingDataEntity borrowingData)
        {
            var existedBorrowinData = await _libraryContext.BorrowingData.FindAsync(id);
            existedBorrowinData.LibraryMembers = borrowingData.LibraryMembers;
            existedBorrowinData.Book = borrowingData.Book;
            existedBorrowinData.RentalTime = borrowingData.RentalTime;
            existedBorrowinData.RetrievalLimitTime = borrowingData.RetrievalLimitTime;
            await _libraryContext.SaveChangesAsync();
            return existedBorrowinData;
        }

        public async Task Delete(BorrowingDataEntity borrowingData)
        {
            _libraryContext.BorrowingData.Remove(borrowingData);
            await _libraryContext.SaveChangesAsync();
        }
    }
}
