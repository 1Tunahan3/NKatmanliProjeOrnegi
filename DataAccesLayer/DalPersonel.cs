using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace DataAccesLayer
{
   public class DalPersonel
    {

        public static List<EntityPersonel> GetList()
        {
          List<EntityPersonel>  degerler=new List<EntityPersonel>();
            SqlCommand komut1=new SqlCommand("Select * From TBLBILGI",Baglanti.bgl);
            if (komut1.Connection.State!=ConnectionState.Open)
            {
                komut1.Connection.Open();
            }

            SqlDataReader dr = komut1.ExecuteReader();
            while (dr.Read())
            {
                EntityPersonel ent=new EntityPersonel();
                ent.Id = int.Parse(dr["ID"].ToString());
                ent.Ad = dr["AD"].ToString();
                ent.Soyad = dr["SOYAD"].ToString();
                ent.Sehir = dr["SEHIR"].ToString();
                ent.Gorev = dr["GOREV"].ToString();
                ent.Maas = short.Parse(dr["MAAS"].ToString());
                degerler.Add(ent);
            }
            dr.Close();
            return degerler;

        }

        public static int PersonelEkle(EntityPersonel e)
        {
            SqlCommand komut2=new SqlCommand("insert into TBLBILGI (AD,SOYAD,SEHIR,GOREV,MAAS) VALUES (@P1,@P2,@P3,@P4,@P5)",Baglanti.bgl);
            if (komut2.Connection.State != ConnectionState.Open)
            {
                komut2.Connection.Open();
            }

            komut2.Parameters.AddWithValue("@P1", e.Ad);
            komut2.Parameters.AddWithValue("@P2", e.Soyad);
            komut2.Parameters.AddWithValue("@P3", e.Sehir);
            komut2.Parameters.AddWithValue("@P4", e.Gorev);
            komut2.Parameters.AddWithValue("@P5", e.Maas);
            return komut2.ExecuteNonQuery();

        }

        public static bool PersonelSil(int p)
        {
            SqlCommand komut=new SqlCommand("Delete from TBLBILGI where ID=@P1",Baglanti.bgl);
            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }

            komut.Parameters.AddWithValue("@P1", p);
            return komut.ExecuteNonQuery() > 0;
        }

        public static bool PersonelGuncelle(EntityPersonel e)
        {
            SqlCommand komut=new SqlCommand("Update TBLBILGI SET AD=@P1,SOYAD=@P2,SEHIR=@P3,GOREV=@P4,MAAS=@P5 WHERE ID=@P6",Baglanti.bgl);
            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }

            komut.Parameters.AddWithValue("@P1", e.Ad);
            komut.Parameters.AddWithValue("@P2", e.Soyad);
            komut.Parameters.AddWithValue("@P3", e.Sehir);
            komut.Parameters.AddWithValue("@P4", e.Gorev);
            komut.Parameters.AddWithValue("@P5", e.Maas);
            komut.Parameters.AddWithValue("@P6", e.Id);

            return komut.ExecuteNonQuery() > 0;

        }
    }
}
