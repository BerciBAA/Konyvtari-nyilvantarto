

using FluentValidation;
using Konyvtar_nyilvantarto;
using Konyvtar_nyilvantarto.Contexts;
using Konyvtar_nyilvantarto.Contracts.LibraryMember;
using Konyvtar_nyilvantarto.Services.LibraryMembers.Repository;
using Konyvtar_nyilvantarto.Services.LibraryMembers.Service;
using Konyvtar_nyilvantarto.Contracts.Book;
using Konyvtar_nyilvantarto.Contracts.BorrowingData;
using Konyvtar_nyilvantarto.Services.BorrowingData.Repository;
using Konyvtar_nyilvantarto.Services.BorrowingData.Service;
using Konyvtar_nyilvantarto.Validators;
using Microsoft.EntityFrameworkCore;
using Konyvtar_nyilvantarto.Validators.LibraryMemberValidators;
using Konyvtar_nyilvantarto.Validators.LibraryMemberValidators.Models;
using Konyvtar_nyilvantarto.Validators.Common;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<LibraryContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("LocalDb"));
    options.UseLazyLoadingProxies();
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IBookRepository, BookRepository>();

builder.Services.AddScoped<IBorrowingDataRepository, BorrowingDataRepository>();
builder.Services.AddScoped<IBorrowingDataService, BorrowingDataService>();
builder.Services.AddScoped<ILibaryMemberService, LibaryMemberService>();
builder.Services.AddScoped<ILibraryMemberRepository, LibraryMemberRepository>();

builder.Services.AddScoped<IValidator<BorrowingRequest>, BorrowingRequestValidator>();
builder.Services.AddScoped<IValidator<BookRequest>, BookRequestValidator>();


builder.Services.AddScoped<IValidator<Guid>, GuidValidator>();
builder.Services.AddScoped<IValidator<CreateLibraryMemberRequest>, CreateLibraryMemberRequestValidator>();
builder.Services.AddScoped<IValidator<QueryParameterValidatorObject>, LibraryMemberQueryParameterValidator>();
builder.Services.AddScoped<IValidator<UpdateLibraryMemberRequest>, UpdateLibraryMemberRequestValidator>();

builder.Services.AddScoped<IValidator<BookRequest>, BookRequestValidator>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
