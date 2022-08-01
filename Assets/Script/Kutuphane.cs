using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace olcay
{




    public class Matematiksel_iþlemler : MonoBehaviour
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

        public static void Toplama(int GelenSayi, List<GameObject> Karakterler, Transform Pozisyon)
        {
            int sayi2 = 0;
            foreach (var item in Karakterler)
            {
                if (sayi2 < GelenSayi)
                {
                    if (!item.activeInHierarchy)
                    {

                        item.transform.position = Pozisyon.position;
                        item.SetActive(true);
                        sayi2++;


                    }
                }
                else
                {
                    sayi2 = 0;
                    break;
                }


            }
            GameManeger.AnlikKarakterSayisi += GelenSayi;


        }

        public static void Cýkarma(int GelenSayi, List<GameObject> Karakterler)
        {

            if (GameManeger.AnlikKarakterSayisi < GelenSayi)
            {
                foreach (var item in Karakterler)
                {
                    item.transform.position = Vector3.zero;
                    item.SetActive(false);
                }
                GameManeger.AnlikKarakterSayisi = 1;

            }
            else
            {
                int sayi3 = 0;
                foreach (var item in Karakterler)
                {
                    if (sayi3 != GelenSayi)
                    {
                        if (item.activeInHierarchy)
                        {

                            item.transform.position = Vector3.zero;
                            item.SetActive(false);
                            sayi3++;


                        }
                    }
                    else
                    {
                        sayi3 = 0;
                        break;
                    }

                }
                GameManeger.AnlikKarakterSayisi -= GelenSayi;

            }


        }

        public static void Bolme(int GelenSayi, List<GameObject> Karakterler)
        {

            if (GameManeger.AnlikKarakterSayisi < 2)
            {
                foreach (var item in Karakterler)
                {
                    item.transform.position = Vector3.zero;
                    item.SetActive(false);
                }
                GameManeger.AnlikKarakterSayisi = 1;

            }
            else
            {

                int bolen = GameManeger.AnlikKarakterSayisi / GelenSayi;

                int sayi3 = 0;
                foreach (var item in Karakterler)
                {
                    if (sayi3 != bolen)
                    {
                        if (item.activeInHierarchy)
                        {

                            item.transform.position = Vector3.zero;
                            item.SetActive(false);
                            sayi3++;


                        }
                    }
                    else
                    {
                        sayi3 = 0;
                        break;
                    }

                }

                if (GameManeger.AnlikKarakterSayisi % GelenSayi == 0)
                {

                    GameManeger.AnlikKarakterSayisi /= GelenSayi;


                }
                else if (GameManeger.AnlikKarakterSayisi % GelenSayi == 1)
                {
                    GameManeger.AnlikKarakterSayisi /= GelenSayi;
                    GameManeger.AnlikKarakterSayisi++;

                }
                else if (GameManeger.AnlikKarakterSayisi % GelenSayi == 2)
                {
                   GameManeger.AnlikKarakterSayisi /= GelenSayi;
                   GameManeger.AnlikKarakterSayisi +=2;
                }


                

            }

        }
    }
   
}
