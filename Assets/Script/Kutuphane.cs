using GoogleMobileAds.Api;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;



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
                PlayerPrefs.SetInt("GecisReklamiSayisi",1);
            }
        }

    }

    //**Reklamlar**//

    public class ReklamYonetim
    {
        private InterstitialAd interstitial;

        private RewardedAd _RewardedAd;
        //GECÝS REKLAMI
        public void RequestInterstitial()
        {

            string AdUnitId;
        #if UNITY_ANDROID
            AdUnitId = "ca-app-pub-3940256099942544/1033173712";

        #elif UNITY_IPHONE
            AdUnitId = "ca-app-pub-3940256099942544/4411468910";

        #else 
            AdUnitId = "unexpected_platform";
#endif

            interstitial = new InterstitialAd(AdUnitId);
            AdRequest request = new AdRequest.Builder().Build();
            interstitial.LoadAd(request);

            interstitial.OnAdClosed += GecisReklamiKapatildi;

        }

        void GecisReklamiKapatildi(object sender, EventArgs args)
        {
            interstitial.Destroy();
            RequestInterstitial();

        }
        
        public void GecisRekalamiGoster()
        {

            if (PlayerPrefs.GetInt("GecisReklamiSayisi")==2)
            {
                if (interstitial.IsLoaded())
                {
                    PlayerPrefs.SetInt("GecisReklamiSayisi",0);
                    interstitial.Show();
                }
                else
                {
                    interstitial.Destroy();
                    RequestInterstitial();
                }
            }
            else
            {
                PlayerPrefs.SetInt("GecisReklamiSayisi",PlayerPrefs.GetInt("GecisReklamiSayisi"+1));
            }

           
        }
        //ODULLU REKLAM

        public void RequestRewardedAd()
        {
            string AdUnitId;
#if UNITY_ANDROID
            AdUnitId = "ca-app-pub-3940256099942544/5224354917";

#elif UNITY_IPHONE
            AdUnitId = "ca-app-pub-3940256099942544/1712485313";

#else
            AdUnitId = "unexpected_platform";
#endif

            _RewardedAd = new RewardedAd(AdUnitId);
            AdRequest request = new AdRequest.Builder().Build();
            _RewardedAd.LoadAd(request);

            _RewardedAd.OnUserEarnedReward += OdulluReklamTamamlandi;
            _RewardedAd.OnAdClosed += OdulluReklamKapatildi;
            _RewardedAd.OnAdLoaded += OdulluReklamKYuklendi;

        }

        private void OdulluReklamTamamlandi(object sender, Reward e)
        {
            Debug.Log("ödül alýndý");
        }

        private void OdulluReklamKapatildi(object sender, EventArgs e)
        {
            Debug.Log("Reklam kapatildi yenide nload edilecek");
            RequestRewardedAd();
        }

        private void OdulluReklamKYuklendi(object sender, EventArgs e)
        {
            Debug.Log("Reklam yüklendi");
        }

        public void OdulluReklamGoster()
        {
            if (_RewardedAd.IsLoaded())
            {
                _RewardedAd.Show();
            }
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

    public class VeriYonetimi
    {
        public void Save(List<ItemBilgileri> _ItemBilgileri)
        {
            
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.OpenWrite(Application.persistentDataPath + "/ItemVerileri.gd");
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

        public void ilkKurulumDosyaOlusturma(List<ItemBilgileri> _ItemBilgileri)
        {

            if (!File.Exists(Application.persistentDataPath + "/ItemVerileri.gd"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Create(Application.persistentDataPath + "/ItemVerileri.gd");
                bf.Serialize(file, _ItemBilgileri);
                file.Close();
            }
        }

    }

}
