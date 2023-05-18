using FluentValidation;
using Konyvtar_nyilvantarto.Contracts.LibraryMember;
using Konyvtar_nyilvantarto.Services.BorrowingData.Repository;
using Konyvtar_nyilvantarto.Services.BorrowingData.Service;
using Konyvtar_nyilvantarto.Services.LibraryMembers.Repository;
using Konyvtar_nyilvantarto.Services.LibraryMembers.Service;
using Konyvtar_nyilvantarto.Validators.LibraryMemberValidators.Models;
using Konyvtar_nyilvantarto.Validators.LibraryMemberValidators;
using Konyvtar_nyilvantarto.Contracts.BorrowingData;
using Konyvtar_nyilvantarto.Validators;
using Konyvtar_nyilvantarto.Contracts.Book;
using Konyvtar_nyilvantarto.Validators.Common;

namespace Konyvtar_nyilvantarto.Extensions
{
    public static class IServiceCollectionExtension
    {
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<ILibraryMemberRepository, LibraryMemberRepository>();
            services.AddScoped<IBorrowingDataRepository, BorrowingDataRepository>();
        }

        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IBorrowingDataService, BorrowingDataService>();
            services.AddScoped<ILibaryMemberService, LibaryMemberService>();
        }

        public static void RegisterLibraryMemberValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<CreateLibraryMemberRequest>, CreateLibraryMemberRequestValidator>();
            services.AddScoped<IValidator<QueryParameterValidatorObject>, LibraryMemberQueryParameterValidator>();
            services.AddScoped<IValidator<UpdateLibraryMemberRequest>, UpdateLibraryMemberRequestValidator>();
        }

        public static void RegisterBorrowingValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<BorrowingRequest>, BorrowingRequestValidator>();
        }

        public static void RegisterBookValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<BookRequest>, BookRequestValidator>();
        }

        public static void RegisterCommonValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<Guid>, GuidValidator>();
        }
    }
}
