using PersonelTakipOtomasyonuApı.Dtos;
using PersonelTakipOtomasyonuApı.Models;

namespace PersonelTakipOtomasyonuApı.Services
{
    public interface IPersonelServices
    {
        List<Personel> GetTumPersoneller();
        
        void PersonelEkle(PersonelOlusturDto personel);
        void PersonelGuncelle(PersonelGuncelleDto personel);
        void PersonelSil(int id);

    }
}
