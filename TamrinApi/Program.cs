using TamrinApi.Database;
using TamrinApi.Interfaces;
using TamrinApi.Models;
using TamrinApi.Repositories;
using TamrinApi.Servises;
using TamrinApi.Database;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IMemberRepository, MemberRepository>();
builder.Services.AddScoped<IBorrowingRepository, BorrowingRepository>();
builder.Services.AddScoped<IGettingBookService,GettingBookService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();
//after this line all of lines are for test excsept app.run
var book = new Book("harry poter", "jk rowling", "fantasy", 1999, 20);
bookDataBase.books.Add(book);
var member = new Member("Alireza Salimian", "alirza1385@gamil.com", "09226844631");
MemberDataBase.members.Add(member);
var borow = new Borrowing(book.ID, member.id);
BorrowDatabase.borrowings.Add(borow);
Console.WriteLine("book  "+book.ID);
Console.WriteLine("member  "+member.id);
Console.WriteLine("borow  " + borow.id);

//after this line all of lines are for test excsept app.run
Book book = new Book("harry poter", "jk rowling", "fantasy", 1999, 20);
bookDataBase.books.Add(book);
Member member = new Member("alireza Salimian", "alirza1385@gamil.com", "09226844631");
MemberDataBase.members.Add(member);
BorrowDatabase.borrowings.Add(new Borrowing(book.ID, member.id));



app.Run();

