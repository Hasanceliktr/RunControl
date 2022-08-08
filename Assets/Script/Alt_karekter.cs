using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Alt_karekter : MonoBehaviour
{
    
    NavMeshAgent _NavMesh;
    public GameManeger _Gamemanager;
    public GameObject Target;
    void Start()
    {
        _NavMesh = GetComponent<NavMeshAgent>();
    }

    private void LateUpdate()
    {
        _NavMesh.SetDestination(Target.transform.position);
    }
    Vector3 Pozisyonver()
    {
      
        return new Vector3(transform.position.x, .23f, transform.position.z);

    }
    private void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("igneliKutu")) 
        {
            _Gamemanager.YokolmaEfektiOlustur(Pozisyonver());
            gameObject.SetActive(false);
        }
        else if (other.CompareTag("Testere"))
        {
            _Gamemanager.YokolmaEfektiOlustur(Pozisyonver());
            gameObject.SetActive(false);
        }
        else if (other.CompareTag("Pervaneigneler"))
        {
            _Gamemanager.YokolmaEfektiOlustur(Pozisyonver());
            gameObject.SetActive(false);
        }
        else if (other.CompareTag("Balyoz"))
        {
            _Gamemanager.YokolmaEfektiOlustur(Pozisyonver(), true);
            gameObject.SetActive(false);
        }
        else if (other.CompareTag("Dusman"))
        {
            _Gamemanager.YokolmaEfektiOlustur(Pozisyonver(), false,false);
            gameObject.SetActive(false);
        }
        else if (other.CompareTag("BosKarakter"))
        {
            _Gamemanager.Karakterler.Add(other.gameObject);
            
        }
    }
}

