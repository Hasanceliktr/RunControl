using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Olcay;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
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
    VeriYonetimi _VeriYonetim = new VeriYonetimi();
    ReklamYonetim _ReklamYonetim = new ReklamYonetim();

    Scene _Scene;
    [Header("GENEL VERÝLER")]
    public AudioSource[] Sesler;
    public GameObject[] islemPanelleri;
    public Slider OyunSesiAyar;
    public List<DilVerileriAnaObje> _DilVerileriAnaObje = new List<DilVerileriAnaObje>();
    List<DilVerileriAnaObje> _DilOkunanVeriler = new List<DilVerileriAnaObje>();
    public Text[] TextObjeleri;
    public GameObject YuklemeEkrani;
    public Slider YuklemeSlider;


    private void Awake()
    {
        Sesler[0].volume = _BellekYonetim.VeriOku_f("OyunSes");
        OyunSesiAyar.value = _BellekYonetim.VeriOku_f("OyunSes");
        Sesler[1].volume = _BellekYonetim.VeriOku_f("MenuFx");
        Destroy(GameObject.FindWithTag("MenuSes"));
        ItemleriKontrolEt();
    }
    void Start()
    {
        
        DusmanlariOlustur();
        _ReklamYonetim.RequestInterstitial();
        _Scene = SceneManager.GetActiveScene();
        _VeriYonetim.Dil_Load();
        _DilOkunanVeriler = _VeriYonetim.DilVerileriListeyiAktar();
        _DilVerileriAnaObje.Add(_DilOkunanVeriler[5]);
        DilTercihiYonetimi();

    }
    void DilTercihiYonetimi()
    {
        if (_BellekYonetim.VeriOku_s("Dil") == "TR")
        {
            for (int i = 0; i < TextObjeleri.Length; i++)
            {
                TextObjeleri[i].text = _DilVerileriAnaObje[0]._DilVerileri_TR[i].Metin;
            }
        }
        else
        {
            for (int i = 0; i < TextObjeleri.Length; i++)
            {
                TextObjeleri[i].text = _DilVerileriAnaObje[0]._DilVerileri_EN[i].Metin;
            }
        }
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
                    islemPanelleri[3].SetActive(true);
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
                    islemPanelleri[2].SetActive(true);

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


    public void CikisButonislem(string durum)
    {
        Sesler[1].Play();
        Time.timeScale = 0;
        if (durum == "durdur")
        {
            islemPanelleri[0].SetActive(true);
        }
        else if (durum == "devamet")
        {
            islemPanelleri[0].SetActive(false);
            Time.timeScale = 1;
        }
        else if (durum == "tekrar")
        {
            SceneManager.LoadScene(_Scene.buildIndex);
            Time.timeScale = 1;
        }
        else if (durum == "Anasayfa")
        {
            SceneManager.LoadScene(5);
            Time.timeScale = 1;
        }
    }

    public void Ayarlar(string durum)
    {
        if (durum == "ayarla")
        {
            islemPanelleri[1].SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            islemPanelleri[1].SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void SesiAyarla()
    {
        _BellekYonetim.VeriKaydet_float("OyunSes", OyunSesiAyar.value);
        Sesler[0].volume = OyunSesiAyar.value;

    }

    public void SonrakiLevel()
    {
        StartCoroutine(LoadAsync(_Scene.buildIndex + 1));
    }
    
        IEnumerator LoadAsync(int sceneIndex)
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

            YuklemeEkrani.SetActive(true);

            while (!operation.isDone)
            {
                float progress = Mathf.Clamp01(operation.progress / .9f);
                YuklemeSlider.value = progress;
                yield return null;
            }
        }

        
       
    
}
        


