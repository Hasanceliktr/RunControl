using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using UnityEngine.EventSystems;
using Olcay;

public class Level_Manager : MonoBehaviour
{
    public Button[] Butonlar;
    public int Level;
    public Sprite KilitliButon;
    public AudioSource ButonSes;
    BellekYonetim _BellekYonetim = new BellekYonetim();

    public List<DilVerileriAnaObje> _DilVerileriAnaObje = new List<DilVerileriAnaObje>();
    List<DilVerileriAnaObje> _DilOkunanVeriler = new List<DilVerileriAnaObje>();
    public Text TextObjeleri;
    VeriYonetimi _VeriYonetim = new VeriYonetimi();
    void Start()
    {
        

        _VeriYonetim.Dil_Load();
        _DilOkunanVeriler = _VeriYonetim.DilVerileriListeyiAktar();
        _DilVerileriAnaObje.Add(_DilOkunanVeriler[2]);
        DilTercihiYonetimi();

        ButonSes.volume = _BellekYonetim.VeriOku_f("MenuFx");

        int mevcutLevel = _BellekYonetim.VeriOku_i ("SonLevel") -4;


        int Index = 1;
        for (int i = 0; i < Butonlar.Length; i++)
        {

            if(Index <= mevcutLevel)
            {
                Butonlar[i].GetComponentInChildren<Text>().text = Index.ToString();
                int SahneIndex = Index + 4;
                Butonlar[i].onClick.AddListener(delegate{ SahneYukle(SahneIndex); });
            }
            else
            {
                Butonlar[i].GetComponent<Image>().sprite = KilitliButon;

                Butonlar[i].enabled = false;
            }
            Index++;
        }

        


    }

    void DilTercihiYonetimi()
    {
        if (PlayerPrefs.GetString("Dil") == "TR")
        {
            

            TextObjeleri.text = _DilVerileriAnaObje[0]._DilVerileri_TR[0].Metin;
        }
        else
        {
            TextObjeleri.text = _DilVerileriAnaObje[0]._DilVerileri_EN[0].Metin;
        }
    }

    public void SahneYukle(int Index)
    {
        ButonSes.Play();
        SceneManager.LoadScene(Index);

    }
    public void GeriDon()
    {
        ButonSes.Play();
        SceneManager.LoadScene(0);
    }
}
