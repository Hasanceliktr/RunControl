using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Olcay;
public class GameManeger : MonoBehaviour
{
    public static int AnlikKarakterSayisi = 1;
    public List<GameObject> Karakterler;
    public List<GameObject> OlusmaEfektleri;
    public List<GameObject> YokOlmaEfektleri;
    public List<GameObject> AdamLekesiEfektleri;

    [Header("LEVEL VERÝLERÝ")]
    public List<GameObject> Dusmanlar;
    public int KacDusmanOlsun;
    public GameObject _AnaKarakter;
    public bool OyunBittimi;
    bool SonaGeldikmi;

    Matematiksel_islemler _Matematiksel_Ýslemler = new Matematiksel_islemler();
    BellekYonetim _BellekYonetim = new BellekYonetim();
    void Start()
    {
        DusmanlariOlustur();
    }

    public void DusmanlariOlustur()
    {
        for (int i = 0; i < KacDusmanOlsun; i++)
        {
            Dusmanlar[i].SetActive(true);
        }
    }

    public void DusmanlariTetikle()
    {
        foreach (var item in Dusmanlar)
        {
            if (item.activeInHierarchy)
            {
                item.GetComponent<Dusman>().AnimasyonTetikle();
            }
        }
        SonaGeldikmi = true;
        SavasDurumu();
    }

    void SavasDurumu()
    {
        if (SonaGeldikmi)
        {

            if (AnlikKarakterSayisi == 1 || KacDusmanOlsun == 0)
            {
                OyunBittimi = true;
                foreach (var item in Dusmanlar)
                {
                    if (item.activeInHierarchy)
                    {
                        item.GetComponent<Animator>().SetBool("Saldir", false);
                    }
                }
                foreach (var item in Karakterler)
                {
                    if (item.activeInHierarchy)
                    {
                        item.GetComponent<Animator>().SetBool("Saldir", false);
                    }
                }

                _AnaKarakter.GetComponent<Animator>().SetBool("Saldir", false);

                if (AnlikKarakterSayisi < KacDusmanOlsun || AnlikKarakterSayisi == KacDusmanOlsun)
                {

                }
            }
        }
    }

    public void AdamYonetimi(string islemturu, int Gelensayi, Transform Pozisyon)
    {
        switch (islemturu)
        {
            case "Carpma":
                _Matematiksel_Ýslemler.Carpma(Gelensayi, Karakterler, Pozisyon,OlusmaEfektleri);
                break;

            case "Toplama":
                _Matematiksel_Ýslemler.Toplama(Gelensayi, Karakterler, Pozisyon,OlusmaEfektleri);
                break;

            case "Cikarma":
                _Matematiksel_Ýslemler.Cikarma(Gelensayi, Karakterler, YokOlmaEfektleri);
                break;


            case "Bolme":
                _Matematiksel_Ýslemler.Bolme(Gelensayi, Karakterler,YokOlmaEfektleri);
                break;

        }


    }
  
    public void YokolmaEfektiOlustur(Vector3 Pozisyon,bool Balyoz=false,bool Durum=false)
    {
        foreach (var item in YokOlmaEfektleri)
        {
            if (!item.activeInHierarchy)
            {
                item.SetActive(true);
                item.transform.position = Pozisyon;
                item.GetComponent<ParticleSystem>().Play();
                if (!Durum)
                    AnlikKarakterSayisi--;
                else
                    KacDusmanOlsun--;
                break;
            }
        }
        
        if (Balyoz)
        {

            Vector3 yeniPoz = new Vector3(Pozisyon.x, .005f, Pozisyon.z);
            foreach (var item in AdamLekesiEfektleri)
            {
                if (!item.activeInHierarchy)
                {
                    item.SetActive(true);
                    item.transform.position = yeniPoz;
                    break;
                }
            }
        }

        if (!OyunBittimi)
            SavasDurumu();

    }



}
        


