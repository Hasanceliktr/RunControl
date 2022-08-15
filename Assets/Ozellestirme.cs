using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Olcay;
using TMPro;


public class Ozellestirme : MonoBehaviour
{
    public Text PuanText;  
    public GameObject[] islemPanelleri;
    public GameObject islemCanvasi;
    public GameObject[] GenelPaneller;
    public Button[] islemButonlari;
    public TextMeshProUGUI SatinAlmaText;
    int AktifislemPaneliIndex;
    [Header("SAPKALAR")]
    public Text SapkaText;
    public GameObject[] Sapkalar;
    public Button[] SapkaButonlari;
    [Header("SOPALAR")]
    public Text SopaText;
    public GameObject[] Sopalar;
    public Button[] SopaButonlari;
    [Header("MATER�YAL")]
    public Text MaterialText;
    public Material[] Materyaller;
    public Button[] MateryalButonlari;
    public SkinnedMeshRenderer _Renderer;

    int SapkaIndex = -1;
    int SopaIndex = -1;
    int MaterialIndex = -1;

    BellekYonetim _BellekYonetim = new BellekYonetim();
    VeriYonetimi _VeriYonetim = new VeriYonetimi();
    [Header("GENEL VER�LER")]
    public List<ItemBilgileri> _ItemBilgileri = new List<ItemBilgileri>();
    
    void Start()
    {
        _BellekYonetim.VeriKaydetme_int("AktifSapka", -1);
        _BellekYonetim.VeriKaydetme_int("AktifSopa", -1);
        _BellekYonetim.VeriKaydetme_int("AktifTema", -1);
        _BellekYonetim.VeriKaydetme_int("Puan", 1500);
        PuanText.text = _BellekYonetim.VeriOku_i("Puan").ToString();


        if (_BellekYonetim.VeriOku_i("AktifSapka") == -1)
        {

            foreach (var item in Sapkalar)
            {
                item.SetActive(false);
            }
            SapkaIndex = -1;
            SapkaText.text = "Sapka yok";


        }
        else
        {
            SapkaIndex = _BellekYonetim.VeriOku_i("AktifSapka");
            Sapkalar[SapkaIndex].SetActive(true);


        }
      

        if (_BellekYonetim.VeriOku_i("AktifSopa") == -1)
        {

            foreach (var item in Sopalar)
            {
                item.SetActive(false);
            }
            SopaIndex = -1;
            SopaText.text = "Sopa yok";


        }
        else
        {

            SopaIndex = _BellekYonetim.VeriOku_i("AktifSopa");
            Sopalar[SopaIndex].SetActive(true);

            if (SapkaIndex != -1)
            {
                Sapkalar[SapkaIndex].SetActive(false);
                SapkaIndex--;
                if (SapkaIndex != -1)
                {
                    Sapkalar[SapkaIndex].SetActive(true);
                    SapkaButonlari[0].interactable = true;
                    SapkaText.text = _ItemBilgileri[SapkaIndex].Item_Ad;


        }

        if (_BellekYonetim.VeriOku_i("AktifTema") == -1)
        {
            Material[] mats = _Renderer.materials;
            mats[0] = Materyaller[0];
            _Renderer.materials = mats;
            MaterialIndex = -1;
            MaterialText.text = "Tema yok";


        }
        else
        {
            MaterialIndex = _BellekYonetim.VeriOku_i("AktifTema");
            Material[] mats = _Renderer.materials;
            mats[0] = Materyaller[MaterialIndex];
            _Renderer.materials = mats;

        }


        // _VeriYonetim.Save(_ItemBilgileri);

         _VeriYonetim.Load();
         _ItemBilgileri = _VeriYonetim.ListeyiAktar();


        

    }

    public void SatinAl()
    {
        if (AktifislemPaneliIndex!=-1)
        {
            switch (AktifislemPaneliIndex)
            {
                case 0:
                    Debug.Log("B�l�m no :" + AktifislemPaneliIndex + "Item Index" + SapkaIndex + "Item Ad" + _ItemBilgileri[SapkaIndex].Item_Ad);
                    break;
                case 1:
                    Debug.Log("B�l�m no :" + AktifislemPaneliIndex + "Item Index" + SopaIndex + "Item Ad" + _ItemBilgileri[SopaIndex+3].Item_Ad);
                    break;
                case 2:
                    Debug.Log("B�l�m no :" + AktifislemPaneliIndex + "Item Index" + MaterialIndex + "Item Ad" + _ItemBilgileri[MaterialIndex+6].Item_Ad);
                    break;
            }
        }
       

    }

    public void Kaydet()
    {
        Debug.Log(AktifislemPaneliIndex);
    }
      

    public void Sapka_Yonbutonlari(string islem)
        {
            if (islem == "ileri")
            {

                if (SapkaIndex == -1)
                {
                    SapkaIndex = 0;
                    Sapkalar[SapkaIndex].SetActive(true);
                    SapkaText.text = _ItemBilgileri[SapkaIndex].Item_Ad;
                }
                else
                {
                    Sapkalar[SapkaIndex].SetActive(false);
                    SapkaIndex++;
                    Sapkalar[SapkaIndex].SetActive(true);
                    SapkaText.text = _ItemBilgileri[SapkaIndex].Item_Ad;
                }

                //------------------------------

                if (SapkaIndex == Sapkalar.Length - 1)
                    SapkaButonlari[1].interactable = false;
                else
                    SapkaButonlari[1].interactable = true;

                if (SapkaIndex != -1)
                    SapkaButonlari[0].interactable = true;


            }
            else
            {
                if (SapkaIndex != -1)
                {
                    Sapkalar[SapkaIndex].SetActive(false);
                    SapkaIndex--;
                    if (SapkaIndex != -1)
                    {
                        Sapkalar[SapkaIndex].SetActive(true);
                        SapkaButonlari[0].interactable = true;
                        SapkaText.text = _ItemBilgileri[SapkaIndex].Item_Ad;

                    }
                    else
                    {
                        SapkaButonlari[0].interactable = false;
                        SapkaText.text = "Sapka yok";
                    }
                }
                else
                {
                    SapkaButonlari[0].interactable = false;
                    SapkaText.text = "Sapka yok";
                }
                //-----------------------------------------------
                if (SapkaIndex != Sapkalar.Length - 1)
                    SapkaButonlari[1].interactable = true;

            }
        }

    public void Sopa_Yonbutonlari(string islem)
        {
            if (islem == "ileri")
            {

                if (SopaIndex == -1)
                {
                    SopaIndex = 0;
                    Sopalar[SopaIndex].SetActive(true);
                    SopaText.text = _ItemBilgileri[SopaIndex +3 ].Item_Ad;
                }
                else
                {
                    Sopalar[SopaIndex].SetActive(false);
                    SopaIndex++;
                    Sopalar[SopaIndex].SetActive(true);
                    SopaText.text = _ItemBilgileri[SopaIndex +3 ].Item_Ad;
                }

                //------------------------------

                if (SopaIndex == Sopalar.Length - 1)
                    SopaButonlari[1].interactable = false;
                else
                    SopaButonlari[1].interactable = true;

                if (SopaIndex != -1)
                    SopaButonlari[0].interactable = true;


            }
            else
            {
                if (SopaIndex != -1)
                {
                    Sopalar[SopaIndex].SetActive(false);
                    SopaIndex--;
                    if (SopaIndex != -1)
                    {
                        Sopalar[SopaIndex].SetActive(true);
                        SopaButonlari[0].interactable = true;
                        SopaText.text = _ItemBilgileri[SopaIndex + 3].Item_Ad;

                }
                    else
                    {
                        SopaButonlari[0].interactable = false;
                        SopaText.text = "Sopa yok";
                    }
                }
                else
                {
                    SopaButonlari[0].interactable = false;
                    SopaText.text = "Sopa yok";
                }
                //-----------------------------------------------
                if (SopaIndex != Sopalar.Length - 1)
                    SopaButonlari[1].interactable = true;

            }
        }

    public void Material_Yonbutonlari(string islem)
    {
        if (islem == "ileri")
        {

            if (MaterialIndex == -1)
            {
                MaterialIndex = 0;
                Material[] mats = _Renderer.materials;
                mats[0] = Materyaller[MaterialIndex];
                _Renderer.materials = mats;

                MaterialText.text = _ItemBilgileri[MaterialIndex + 6].Item_Ad;
            }
            else
            {
                
                MaterialIndex++;
                Material[] mats = _Renderer.materials;
                mats[0] = Materyaller[MaterialIndex];
                _Renderer.materials = mats;

                MaterialText.text = _ItemBilgileri[MaterialIndex + 6].Item_Ad;
            }

            //------------------------------

            if (MaterialIndex == Materyaller.Length - 1)
               MateryalButonlari[1].interactable = false;
            else
                MateryalButonlari[1].interactable = true;

            if (MaterialIndex != -1)
                MateryalButonlari[0].interactable = true;

        }
        else
        {
            if (MaterialIndex != -1)
            {
                
                MaterialIndex--;
                if (MaterialIndex != -1)
                {
                    
                    Material[] mats = _Renderer.materials;
                    mats[0] = Materyaller[MaterialIndex];
                    _Renderer.materials = mats;

                    MateryalButonlari[0].interactable = true;
                    MaterialText.text = _ItemBilgileri[MaterialIndex + 6].Item_Ad;

                }
                else
                {
                    MateryalButonlari[0].interactable = false;
                    MaterialText.text = "Tema yok";
                }
            }
            else
            {
                MateryalButonlari[0].interactable = false;
                MaterialText.text = "Tema yok";
            }
            //-----------------------------------------------
            if (MaterialIndex != Materyaller.Length - 1)
                MateryalButonlari[1].interactable = true;

        }
    }
    public void islemPaneliCikart(int Index)
    {
        GenelPaneller[0].SetActive(true);
        AktifislemPaneliIndex = Index;
        islemPanelleri[Index].SetActive(true);
        GenelPaneller[1].SetActive(true);
        islemCanvasi.SetActive(false);

    }
    public void GeriDon()
    {
        GenelPaneller[0].SetActive(false);
        islemCanvasi.SetActive(true);
        GenelPaneller[1].SetActive(false);
        islemPanelleri[AktifislemPaneliIndex].SetActive(false);
        AktifislemPaneliIndex = -1;

    }
}
   

