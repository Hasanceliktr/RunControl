using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BosKarakter : MonoBehaviour
{
    public SkinnedMeshRenderer _Renderer;
    public Material AtanacakOlanMateryal;
    public NavMeshAgent _NavMesh;
    public Animator _Animator;
    public GameObject Target;
    bool Temasvar;
    public GameManeger _GameManeger;
    private void LateUpdate()
    {
        if(Temasvar)
       
            _NavMesh.SetDestination(Target.transform.position);
        
        
    }
    Vector3 Pozisyonver()
    {

        return new Vector3(transform.position.x, .23f, transform.position.z);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AltKarekterler") || other.CompareTag("Player"))
        {

            if (gameObject.CompareTag("BosKarakter"))
            {
                MaterialDegistirveAnimasyonTetikle();
                Temasvar = true;
                GetComponent<AudioSource>().Play();
            }
        }
        else if (other.CompareTag("igneliKutu"))
        {
            _GameManeger.YokolmaEfektiOlustur(Pozisyonver());
            gameObject.SetActive(false);
        }
        else if (other.CompareTag("Testere"))
        {
            _GameManeger.YokolmaEfektiOlustur(Pozisyonver());
            gameObject.SetActive(false);
        }
        else if (other.CompareTag("Pervaneigneler"))
        {
            _GameManeger.YokolmaEfektiOlustur(Pozisyonver());
            gameObject.SetActive(false);
        }
        else if (other.CompareTag("Balyoz"))
        {
            _GameManeger.YokolmaEfektiOlustur(Pozisyonver(), true);
            gameObject.SetActive(false);
        }




        else if (other.CompareTag("Dusman"))
        {
            
            _GameManeger.YokolmaEfektiOlustur(Pozisyonver(), false, false);
            gameObject.SetActive(false);
        }
    }

    void MaterialDegistirveAnimasyonTetikle()
    {
        Material[] mats = _Renderer.materials;
        mats[0] = AtanacakOlanMateryal;
        _Renderer.materials = mats;
        _Animator.SetBool("Saldir",true);
        gameObject.tag = "AltKarekterler";
        GameManeger.AnlikKarakterSayisi++;

    }

}
