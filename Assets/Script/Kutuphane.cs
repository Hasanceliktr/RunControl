using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace olcay
{




    public class Kutuphane : MonoBehaviour
    {
    
    
       public static void Carpma(int GelenSayi,List<GameObject> Karakterler,Transform Pozisyon)
        {
            int DonguSayisi = (GameManeger.AnlikKarakterSayisi * GelenSayi) - GameManeger.AnlikKarakterSayisi;
            int sayi = 0;
            foreach (var item in Karakterler)
            {
                if (sayi < DonguSayisi)
                {
                    if (!item.activeInHierarchy)
                    {

                        item.transform.position = Pozisyon.position;
                        item.SetActive(true);
                        sayi++;

                    }
                }
                else
                {
                    sayi = 0;
                    break;
                }

            }
            GameManeger.AnlikKarakterSayisi *= GelenSayi;


        }
    
    
    
    
    
    }
   
        
    
}
