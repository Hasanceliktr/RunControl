using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Olcay;

public class Market_Manager : MonoBehaviour
{
    [Header("----------DÝL VERÝLERÝ")]
    public List<DilVerileriAnaObje> _DilVerileriAnaObje = new List<DilVerileriAnaObje>();
    List<DilVerileriAnaObje> _DilOkunanVeriler = new List<DilVerileriAnaObje>();
    public Text TextObjeleri;
    VeriYonetimi _VeriYonetim = new VeriYonetimi();
    BellekYonetim _BellekYonetim = new BellekYonetim();
    void Start()
    {
        _VeriYonetim.Dil_Load();
        _DilOkunanVeriler = _VeriYonetim.DilVerileriListeyiAktar();
        _DilVerileriAnaObje.Add(_DilOkunanVeriler[3]);
        DilTercihiYonetimi();
    }

    void DilTercihiYonetimi()
    {
        
         if (_BellekYonetim.VeriOku_s("Dil") == "TR")
               TextObjeleri.text = _DilVerileriAnaObje[0]._DilVerileri_TR[0].Metin;
         else
            TextObjeleri.text = _DilVerileriAnaObje[0]._DilVerileri_EN[0].Metin;
    }
}
