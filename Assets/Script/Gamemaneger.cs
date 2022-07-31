using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemaneger : MonoBehaviour
{


    
    public GameObject VarisNoktasi;
    public int AnlikKarakterSayisi = 1;
    public List<GameObject> Karakterler;
    void Start()
    {

    }

    // Update is called once per frame
    void Update() {
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

    public void AdamYonetimi(string veri, Transform Pozisyon)
    {
        switch (veri)
        {
            case "x2":
                int sayi = 0;
                foreach (var item in Karakterler)
                {
                    if (sayi < AnlikKarakterSayisi)
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
                AnlikKarakterSayisi *= 2;
                Debug.Log("2 ile carpildi");
                break;

             case "+3":
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

            case "-4":


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





                }

                int sayi3 = 0;
                foreach (var item in Karakterler)
                {
                    if (sayi3 !=4)
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


                break;
        }
    }
}
        


