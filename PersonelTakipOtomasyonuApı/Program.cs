
using PersonelTakipOtomasyonuApı.Dtos;
using PersonelTakipOtomasyonuApı.Services;

namespace PersonelTakipOtomasyonuApı
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapGet("/Personel", () =>
            {
                IPersonelServices personelServices = new PersonelServices();

                return personelServices.GetTumPersoneller();
            });


            app.MapPost("/personel", (PersonelOlusturDto personel) =>
            {
                IPersonelServices personelService = new PersonelServices();

                personelService.PersonelEkle(personel);
            });

            app.MapPut("/personel", (PersonelGuncelleDto personel) =>
            {
                IPersonelServices personelServices = new PersonelServices();

                personelServices.PersonelGuncelle(personel);
            });

            app.MapDelete("/personel", (int id) =>
            {
                IPersonelServices otomobilService = new PersonelServices();

                otomobilService.PersonelSil(id);
            });

            app.Run();
        }
    }
}
