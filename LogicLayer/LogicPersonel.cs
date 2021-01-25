using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccesLayer;
using EntityLayer;

namespace LogicLayer
{
    public class LogicPersonel
    {

        public static List<EntityPersonel> LLPersonelListesi()
        {
            return DalPersonel.GetList();
        }

        public static int LLPersonelEkle(EntityPersonel p)
        {
            if (p.Ad!="" &&p.Soyad!="")
            {
                return DalPersonel.PersonelEkle(p);
            }
            else
            {
                return -1;
            }
        }

        public static bool LLPersonelSilme(int per)
        {
            if (per>0)
            {
                return DalPersonel.PersonelSil(per);
            }
            else
            {
                return false;
            }
        }

        public static bool LLPersonelGuncelle(EntityPersonel entity)
        {
            return DalPersonel.PersonelGuncelle(entity);
        }


    }
}
