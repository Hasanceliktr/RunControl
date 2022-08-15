using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Olcay;
public class AnaMenu_Manager : MonoBehaviour
{
    BellekYonetim _BellekYonetim = new BellekYonetim();
    VeriYonetimi _VeriYonetim = new VeriYonetimi();
    public GameObject CikisPaneli;
    public List<ItemBilgileri> _ItemBilgileri = new List<ItemBilgileri>();
    ReklamYonetim _ReklamYonetim = new ReklamYonetim();



    void Start()
    {
        _BellekYonetim.KontrolEtVeTanimla();

        //_VeriYonetim.ilkKurulumDosyaOlusturma(_ItemBilgileri);

        _ReklamYonetim.RequestRewardedAd();
        _ReklamYonetim.OdulluReklamGoster();
    }

    public void SahneYukle(int Index)
    {
        SceneManager.LoadScene(Index);
    }

    public void Oyna()
    {
        SceneManager.LoadScene("Level1");
        //Daha sonrasýnda son level olarak düzenlecek
        //SceneManager.LoadScene(_BellekYonetim.VeriOku_i("SonLevel"));
    }
    
    public void CikisButonislem(string durum)
    {
        if (durum == "Evet")
            Application.Quit();
        else if (durum == "cikis")
            CikisPaneli.SetActive(true);
        else
        CikisPaneli.SetActive(false);
    }
}
