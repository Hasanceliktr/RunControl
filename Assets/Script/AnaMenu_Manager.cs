using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Olcay;
using UnityEngine.UI;
using TMPro;
public class AnaMenu_Manager : MonoBehaviour
{
    BellekYonetim _BellekYonetim = new BellekYonetim();
    VeriYonetimi _VeriYonetim = new VeriYonetimi();
    public GameObject CikisPaneli;
    public List<ItemBilgileri>  _Varsayýlan_ItemBilgileri = new List<ItemBilgileri>();
    public List<DilVerileriAnaObje> _Varsayýlan_Dilverileri = new List<DilVerileriAnaObje>();
    public AudioSource ButonSes;

    ReklamYonetim _ReklamYonetim = new ReklamYonetim();

    public List<DilVerileriAnaObje> _DilVerileriAnaObje = new List<DilVerileriAnaObje>();
    List<DilVerileriAnaObje> _DilOkunanVeriler = new List<DilVerileriAnaObje>();
    public Text[] TextObjeleri;
    public GameObject YuklemeEkrani;
    public Slider YuklemeSlider;

    void Start()
    {
        _BellekYonetim.KontrolEtVeTanimla();
        _VeriYonetim.ilkKurulumDosyaOlusturma(_Varsayýlan_ItemBilgileri,_Varsayýlan_Dilverileri);
        ButonSes.volume = _BellekYonetim.VeriOku_f("MenuFx");

         //_BellekYonetim.VeriOku_f("Dil");

       // _BellekYonetim.VeriKaydet_string("Dil", "TR");
        ///

        _VeriYonetim.Dil_Load();
        _DilOkunanVeriler  = _VeriYonetim.DilVerileriListeyiAktar();
        _DilVerileriAnaObje.Add(_DilOkunanVeriler[0]);
        DilTercihiYonetimi();
        

        
       

        _ReklamYonetim.RequestRewardedAd();
        _ReklamYonetim.OdulluReklamGoster();
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

    public void SahneYukle(int Index)
    {
        SceneManager.LoadScene(Index);
    }

    public void Oyna()
    {
        //SceneManager.LoadScene("Level1");
        //Daha sonrasýnda son level olarak düzenlecek
        ButonSes.Play();
       

        StartCoroutine(LoadAsync(_BellekYonetim.VeriOku_i("Level1")));
        //Burayý tekrar SonLevel diye düzeltecez
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
    public void CikisButonislem(string durum)
    {
        ButonSes.Play();
        if (durum == "Evet")
            Application.Quit();
        else if (durum == "cikis")
            CikisPaneli.SetActive(true);
        else
        CikisPaneli.SetActive(false);
    }
}
