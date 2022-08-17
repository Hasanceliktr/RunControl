using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Olcay;
using UnityEngine.SceneManagement;
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
    [Header("SAPKALAR")]
    public GameObject[] Sapkalar;
    [Header("SOPALAR")]
    public GameObject[] Sopalar;
    [Header("MATERYALLER")]
    public Material[] Materyaller;
    public SkinnedMeshRenderer _Renderer;
    public Material VarsayilanTema;

    Matematiksel_islemler _Matematiksel_Ýslemler = new Matematiksel_islemler();
    BellekYonetim _BellekYonetim = new BellekYonetim();
    ReklamYonetim _ReklamYonetim = new ReklamYonetim();

    Scene _Scene;
    private void Awake()
    {
        Destroy(GameObject.FindWithTag("MenuSes"));
        ItemleriKontrolEt();
    }
    void Start()
    {
        DusmanlariOlustur();
        _ReklamYonetim.RequestInterstitial();
        _Scene = SceneManager.GetActiveScene();
        
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

                _ReklamYonetim.GecisRekalamiGoster();
                if (AnlikKarakterSayisi < KacDusmanOlsun || AnlikKarakterSayisi == KacDusmanOlsun)
                {
                    Debug.Log("Kaybettin.");
                }
                else
                {
                    if (AnlikKarakterSayisi > 5)
                    {
                       

                        if (_Scene.buildIndex == _BellekYonetim.VeriOku_i("SonLevel"))
                        {
                            _BellekYonetim.VeriKaydetme_int("Puan", _BellekYonetim.VeriOku_i("Puan") + 600);
                            _BellekYonetim.VeriKaydetme_int("SonLevel", _BellekYonetim.VeriOku_i("SonLevel") + 1);
                        }

                        


                    }
                    
                    else
                    {
                        if (_Scene.buildIndex == _BellekYonetim.VeriOku_i("SonLevel"))
                        {
                            _BellekYonetim.VeriKaydetme_int("Puan", _BellekYonetim.VeriOku_i("Puan") + 200);
                            _BellekYonetim.VeriKaydetme_int("SonLevel", _BellekYonetim.VeriOku_i("SonLevel") + 1);
                        }
                            
                    }
                    Debug.Log("Kazandýn");
                        
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
                item.GetComponent<AudioSource>().Play();
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


    public void ItemleriKontrolEt()
    {
        if(_BellekYonetim.VeriOku_i("AktifSapka")!=-1)
        Sapkalar[_BellekYonetim.VeriOku_i("AktifSapka")].SetActive(true);

        if (_BellekYonetim.VeriOku_i("AktifSopa") != -1)
            Sopalar[_BellekYonetim.VeriOku_i("AktifSopa")].SetActive(true);


        if (_BellekYonetim.VeriOku_i("AktifTema") != -1)
        {
            Material[] mats = _Renderer.materials;
            mats[0] = Materyaller[_BellekYonetim.VeriOku_i("AktifTema")];
            _Renderer.materials = mats;
           

        }
        else
        {
            Material[] mats = _Renderer.materials;
            mats[0] = VarsayilanTema;
            _Renderer.materials = mats;
        }
           
    }
}
        


