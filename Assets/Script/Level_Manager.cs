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
    void Start()
    {

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
