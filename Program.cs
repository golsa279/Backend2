using Ark.Library.Backend.API.Data;
using Ark.Library.Backend.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<LibraryDatabase>(Options=>{
    Options.UseSqlServer(builder.Configuration.GetConnectionString("MainDB"));
    //hard-coded
});
builder.Services.AddCors(Options=>{
    Options.AddDefaultPolicy(policy=>{
        policy.AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin();
    });
});
var app = builder.Build();
app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapGet("/books/list",(LibraryDatabase db)=>{
    Thread.Sleep(2000)
    return db.Books.ToList();
});
app.MapPost("/books/add",(LibraryDatabase db,Book book)=>{
    db.Books.Add(book);
    db.SaveChanges();
});
app.MapPost("/members/add",(LibraryDatabase db,Member member)=>{
    db.Members.Add(member);
    db.SaveChanges();
});
app.MapPost("/borrws/add",(LibraryDatabase db,Borrow borrow)=>{
    db.Borrows.Add(borrow);
    db.SaveChanges();
});
app.UseHttpsRedirection();
app.MapGet("/memberss/list",(LibraryDatabase db)=>{
    return db.Members.ToList();
});
app.UseHttpsRedirection();
app.MapGet("/borrows/list",(LibraryDatabase db)=>{
    return db.Borrows.Include(m=>m.Book).Include(m=>m.Member).ToList();
});



app.Run();

