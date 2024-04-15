using Domain;
using Infrastrucure;
using Microsoft.EntityFrameworkCore;

TheaterAppDbContext dbContext = new();
DbSet<Play> playTable = dbContext.Set<Play>();

//Создание сущностей
CreatePlay(dbContext);

//Получение сущностей
List<Theater> theaters = dbContext.Set<Theater>()
                                    .Include(t => t.Plays)
                                    .Where(t => t.Id == 1)
                                    .ToList();

var theater1 = dbContext.Set<Theater>()
                                    .Include(t => t.Plays)
                                    .FirstOrDefault(a => a.Id == 1);

var newPlay = new Play("Завершающее выступление", "Герасимов", DateTime.UtcNow.AddMinutes(10), DateTime.UtcNow.AddMinutes(15));
theater1.Plays.Add(newPlay);

foreach (Theater theater in theaters) {
    Console.WriteLine(theater);
 } 

Console.WriteLine("finish work");

void CreatePlay(TheaterAppDbContext dbContext)
{
    Theater theater = new("google meet", "****", "89123121", DateTime.Parse("2012-11-13"));

    Play play = new("В честь субботнего отдыха", "Нехваток времени в четврг", DateTime.UtcNow, DateTime.UtcNow);
    theater.Plays.Add(play);
    playTable.Add(play);
    dbContext.Set<Theater>().Add(theater);

    dbContext.SaveChanges();
}