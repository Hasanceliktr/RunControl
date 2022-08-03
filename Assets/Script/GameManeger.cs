using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using olcay;
public class GameManeger : MonoBehaviour
{



    public GameObject VarisNoktasi;
    public static int AnlikKarakterSayisi = 1;
    public List<GameObject> Karakterler;
    public List<GameObject> OlusmaEfektleri;
    public List<GameObject> YokOlmaEfektleri;
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
                Matematiksel_islemler.Carpma(Gelensayi, Karakterler, Pozisyon,OlusmaEfektleri);
                break;

            case "Toplama":
                Matematiksel_islemler.Toplama(Gelensayi, Karakterler, Pozisyon,OlusmaEfektleri);
                break;

            case "Cikarma":
                Matematiksel_islemler.Cikarma(Gelensayi, Karakterler, YokOlmaEfektleri);
                break;


            case "Bolme":
                Matematiksel_islemler.Bolme(Gelensayi, Karakterler,YokOlmaEfektleri);
                break;

        }


    }
  
    public void YokolmaEfektiOlustur(Vector3 Pozisyon)
    {
        foreach (var item in YokOlmaEfektleri)

        {
            if (!item.activeInHierarchy)
            {
                item.SetActive(true);
                item.transform.position = Pozisyon;
                item.GetComponent<ParticleSystem>().Play();
                AnlikKarakterSayisi--;
                break;
            }
        }



    }
}
        


