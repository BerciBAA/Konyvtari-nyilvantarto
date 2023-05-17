using FluentValidation;
using Konyvtar_nyilvantarto;
using Konyvtar_nyilvantarto.Contexts;
using Konyvtar_nyilvantarto.Contracts.LibraryMember;
using Konyvtar_nyilvantarto.Services.LibraryMembers.Repository;
using Konyvtar_nyilvantarto.Services.LibraryMembers.Service;
using Konyvtar_nyilvantarto.Contracts.Book;
using Konyvtar_nyilvantarto.Validators;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<LibraryContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("LocalDb"));
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IBookService, BookService>();
builder.Services.AddSingleton<IBookRepository, BookRepository>();

builder.Services.AddScoped<ILibaryMemberService, LibaryMemberService>();
builder.Services.AddScoped<ILibraryMemberRepository, LibraryMemberRepository>();

builder.Services.AddScoped<IValidator<CreateLibraryMemberRequest>, CreateLibraryMemberRequestValidator>();

builder.Services.AddScoped<IValidator<CreateBookRequest>, CreateBookRequestValidator>();

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
