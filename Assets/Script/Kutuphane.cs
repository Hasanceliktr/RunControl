using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;



namespace Olcay
{


    public class Matematiksel_islemler 
    {

        public void Carpma(int GelenSayi,List<GameObject> Karakterler,Transform Pozisyon, List<GameObject> OlusturmaEfektleri)
        {
            int DonguSayisi = (GameManeger.AnlikKarakterSayisi * GelenSayi) - GameManeger.AnlikKarakterSayisi;
            int sayi = 0;
            foreach (var item in Karakterler)
            {
                if (sayi < DonguSayisi)
                {
                    if (!item.activeInHierarchy)
                    {
                       
                        
                            foreach (var item2 in OlusturmaEfektleri)
                            {


                                if (!item2.activeInHierarchy)
                                {
                                    

                                    item2.SetActive(true);
                                    item2.transform.position = Pozisyon.position;
                                    item2.GetComponent<ParticleSystem>().Play();
                                    item2.GetComponent<AudioSource>().Play();
                                    break;

                                }

                            }


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

        public void Toplama(int GelenSayi, List<GameObject> Karakterler, Transform Pozisyon, List<GameObject> OlusturmaEfektleri)
        {
            int sayi2 = 0;
            foreach (var item in Karakterler)
            {
                if (sayi2 < GelenSayi)
                {
                    if (!item.activeInHierarchy)
                    {

                        foreach (var item2 in OlusturmaEfektleri)
                        {

                            if (!item2.activeInHierarchy)
                            {
                                item2.SetActive(true);
                                item2.transform.position = Pozisyon.position;
                                item2.GetComponent<ParticleSystem>().Play();
                                item2.GetComponent<AudioSource>().Play();
                                break;

                            }

                        }



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

        public void Cikarma(int GelenSayi, List<GameObject> Karakterler,List<GameObject> YokOlmaEfektleri)
        {

            if (GameManeger.AnlikKarakterSayisi < GelenSayi)
            {
                foreach (var item in Karakterler)
                {
                    foreach (var item2 in YokOlmaEfektleri)
                    {

                        if (!item2.activeInHierarchy)
                        {

                            Vector3 yeniPoz = new Vector3(item.transform.position.x, .23f, item.transform.position.z);
                            item2.SetActive(true);
                            item2.transform.position = yeniPoz;
                            item2.GetComponent<ParticleSystem>().Play();
                            item2.GetComponent<AudioSource>().Play();

                            break;

                        }

                    }



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

                            foreach (var item2 in YokOlmaEfektleri)
                            {


                                if (!item2.activeInHierarchy)
                                {
                                    Vector3 yeniPoz = new Vector3(item.transform.position.x, .23f, item.transform.position.z);

                                    item2.SetActive(true);
                                    item2.transform.position = yeniPoz;
                                    item2.GetComponent<ParticleSystem>().Play();
                                    item2.GetComponent<AudioSource>().Play();
                                    break;

                                }

                            }





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

        public void Bolme(int GelenSayi, List<GameObject> Karakterler,List<GameObject> YokOlmaEfektleri)
        {

            if (GameManeger.AnlikKarakterSayisi < 2)
            {
                foreach (var item in Karakterler)
                {
                    foreach (var item2 in YokOlmaEfektleri)
                    {


                        if (!item2.activeInHierarchy)
                        {
                            Vector3 yeniPoz = new Vector3(item.transform.position.x, .23f, item.transform.position.z);

                            item2.SetActive(true);
                            item2.transform.position = yeniPoz;
                            item2.GetComponent<ParticleSystem>().Play();
                            item2.GetComponent<AudioSource>().Play();
                            break;

                        }

                    }


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
                            foreach (var item2 in YokOlmaEfektleri)
                            {


                                if (!item2.activeInHierarchy)
                                {
                                    Vector3 yeniPoz = new Vector3(item.transform.position.x, .23f, item.transform.position.z);

                                    item2.SetActive(true);
                                    item2.transform.position = yeniPoz;
                                    item2.GetComponent<ParticleSystem>().Play();
                                    item2.GetComponent<AudioSource>().Play();

                                    break;

                                }

                            }

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

    public class BellekYonetim
    {
        public void VeriKaydet_string(string Key,string value)
        {
            PlayerPrefs.SetString(Key, value);
            PlayerPrefs.Save();
        }

        public void VeriKaydetme_int(string Key,int value)
        {
            PlayerPrefs.SetInt(Key, value);
            PlayerPrefs.Save();
        }

        public void VeriKaydet_float(string Key, float value)
        {
            PlayerPrefs.SetFloat(Key, value);
            PlayerPrefs.Save();
        }


        public string VeriOku_s(string Key)
        {
           return PlayerPrefs.GetString(Key);
        }

        public int VeriOku_i(string Key)
        {
            return PlayerPrefs.GetInt(Key);
        }

        public float VeriOku_f(string Key)
        {
            return PlayerPrefs.GetFloat(Key);
        }

        public void KontrolEtVeTanimla()
        {
            if (!PlayerPrefs.HasKey("SonLevel"))
            {
                PlayerPrefs.SetInt("SonLevel",5);
                PlayerPrefs.SetInt("Puan",100);

            }
        }

    }

    //**Reklamlar**//

    public class ReklamYonetim
    {
        private InterstitialAd interstitial;

        public void RequestInterstitial()
        {
           
   

        }




    }
   
    public class Verilerimiz
    {
        public static List<ItemBilgileri> _ItemBilgileri = new List<ItemBilgileri>();


    }


    [Serializable]
    public class ItemBilgileri
    {
        public int GrupIndex;
        public int Item_Index;
        public string Item_Ad;
        public int Puan;
        public bool SatinAlmaDurumu;

    }

    public class VeriYonetim
    {
        public void Save(List<ItemBilgileri> _ItemBilgileri)
        {
            //_ItemBilgileri[1].SatinAlmaDurumu = true;
            _ItemBilgileri.Add(new ItemBilgileri());
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/ItemVerileri.gd");
            bf.Serialize(file, _ItemBilgileri);
            file.Close();


        }
        List<ItemBilgileri> _ItemicListe;

        public void Load()
        {
            if (File.Exists(Application.persistentDataPath + "/ItemVerileri.gd"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(Application.persistentDataPath + "/ItemVerileri.gd", FileMode.Open);
                _ItemicListe = (List<ItemBilgileri>)bf.Deserialize(file);
                file.Close();

            }
        }

        public List<ItemBilgileri> ListeyiAktar()
        {
            return _ItemicListe;
            
        }
    }

}
