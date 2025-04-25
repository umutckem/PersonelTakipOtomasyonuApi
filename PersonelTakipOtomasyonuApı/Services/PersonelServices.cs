using PersonelTakipOtomasyonuApı.Dtos;
using PersonelTakipOtomasyonuApı.Efcore;
using PersonelTakipOtomasyonuApı.Models;

namespace PersonelTakipOtomasyonuApı.Services
{
    public class PersonelServices : IPersonelServices
    {
        private readonly PersonelOtomasyonuEklemeDbContext _dbContext;
        public PersonelServices()
        {
            _dbContext = new PersonelOtomasyonuEklemeDbContext();
        }
        public List<Personel> GetTumPersoneller()
        {
            var personeller = _dbContext.personels.ToList();
            return personeller;
        }

        public void PersonelEkle(PersonelOlusturDto personel)
        {
            var eklencekPersonel = new Personel
            {
                Ad = personel.Ad,
                Soyad = personel.Soyad,
                TCKimlikNo = personel.TCKimlikNo,
                TelefonNo = personel.TelefonNo,
                DogumTarihi = personel.DogumTarihi,
                Eposta = personel.Eposta,
                Pozisyon = personel.Pozisyon,
                Departman = personel.Departman,
                Sifre = personel.Sifre,
                IseBaslamaTarihi = DateTime.Now,
                Maas = personel.Maas,
                yıllıkİzinHakkı = personel.yıllıkİzinHakkı,
                aktifMi = personel.aktifMi
                
            };
            _dbContext.personels.Add(eklencekPersonel);
            _dbContext.SaveChanges();
        }

        public void PersonelGuncelle(PersonelGuncelleDto personel)
        {
            var guncellenecek = _dbContext.personels.Find(personel.PersonelID);
            if (guncellenecek is not null)
            {

                guncellenecek.PersonelID = personel.PersonelID;
                guncellenecek.IseBaslamaTarihi = personel.IseBaslamaTarihi;
                guncellenecek.Ad = personel.Ad;
                guncellenecek.Soyad = personel.Soyad;
                guncellenecek.TCKimlikNo = personel.TCKimlikNo;
                guncellenecek.TelefonNo = personel.TelefonNo;
                guncellenecek.DogumTarihi = personel.DogumTarihi;
                guncellenecek.Eposta = personel.Eposta;
                guncellenecek.Pozisyon = personel.Pozisyon;
                guncellenecek.Sifre = personel.Sifre;
                guncellenecek.Departman = personel.Departman;
                guncellenecek.Maas = personel.Maas;
                guncellenecek.aktifMi = personel.aktifMi;
                guncellenecek.yıllıkİzinHakkı = personel.yıllıkİzinHakkı;
                _dbContext.SaveChanges();
            }
        }

        public void PersonelSil(int id)

        {
            var personel = _dbContext.personels.Find(id);
            if (personel is not null)
            {
                _dbContext.personels.Remove(personel);

                _dbContext.SaveChanges();
            }
        }
    }
}
