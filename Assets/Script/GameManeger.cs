using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using olcay;
public class GameManeger : MonoBehaviour
{



    public GameObject VarisNoktasi;
    public static int AnlikKarakterSayisi = 1;
    public List<GameObject> Karakterler;
    void Start()
    {

    }

    
    void Update()
    {
       
    }

    public void AdamYonetimi(string islemturu, int Gelensayi, Transform Pozisyon)
    {
        switch (islemturu)
        {
            case "Carpma":
                Matematiksel_i�lemler.Carpma(Gelensayi, Karakterler, Pozisyon);
                break;

            case "Toplama":
                Matematiksel_i�lemler.Toplama(Gelensayi, Karakterler, Pozisyon);
                break;

            case "Cikarma":
                Matematiksel_i�lemler.Cikarma(Gelensayi, Karakterler);
                break;


            case "Bolme":
                Matematiksel_i�lemler.Bolme(Gelensayi, Karakterler);
                break;

        }


    }
  
}
        


