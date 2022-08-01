using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using olcay;
public class GameManeger : MonoBehaviour
{



    public GameObject VarisNoktasi;
    public static int AnlikKarakterSayisi = 1;
    public List<GameObject> Karakterler;
    void Start()
    {

    }

    // Update is called once per frametest
    void Update()
    {
        //    if (Input.GetKeyDown(KeyCode.A))

        //        foreach (var item in Karakterler)
        //        {

        //            if (!item.activeInHierarchy)
        //            {

        //                item.transform.position = DogmaNoktasý.transform.position;
        //                item.SetActive(true);
        //                AnlikKarakterSayisi++;
        //                break;

        //            }


        //        }
    }

    public void AdamYonetimi(string islemturu, int Gelensayi, Transform Pozisyon)
    {
        switch (islemturu)
        {
            case "Carpma":
               Kutuphane.Carpma(Gelensayi,Karakterler,Pozisyon);
                
                
                break;

            case "Toplama":
                int sayi2 = 0;
                foreach (var item in Karakterler)
                {
                    if (sayi2 < 3)
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
                AnlikKarakterSayisi += 3;


                break;

            case "Cikarma":


                if (AnlikKarakterSayisi < 4)
                {
                    foreach (var item in Karakterler)
                    {
                        item.transform.position = Vector3.zero;
                        item.SetActive(false);
                    }
                    AnlikKarakterSayisi = 1;

                }
                else
                {
                int sayi3 = 0;
                foreach (var item in Karakterler)
                {
                    if (sayi3 != 4)
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
                AnlikKarakterSayisi -= 4;

        }

                break;

            case "Bolme":


                if (AnlikKarakterSayisi < 2)
                {
                    foreach (var item in Karakterler)
                    {
                        item.transform.position = Vector3.zero;
                        item.SetActive(false);
                    }
                    AnlikKarakterSayisi = 1;

                }
                else
                {

                    int bolen = AnlikKarakterSayisi /2;

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
                    if (AnlikKarakterSayisi % 2 == 0)
                    {
                        AnlikKarakterSayisi /= 2;
                        AnlikKarakterSayisi++;
                    }

                }

                break;






        }
    }
}
        


