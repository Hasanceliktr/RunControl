using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Alt_karekter : MonoBehaviour
{
    GameObject Target;
    NavMeshAgent _NavMesh;
    void Start()
    {
        _NavMesh = GetComponent<NavMeshAgent>();
        Target = GameObject.FindWithTag("GameManager").GetComponent<GameManeger>().VarisNoktasi;
    }

    // Update is called once per frame
    private void LateUpdate()
    {

        _NavMesh.SetDestination(Target.transform.position);

    }

    private void OnTriggerEnter (Collider other)
    
    {
        if (other.CompareTag("igneliKutu")) 
        
        {
            Vector3 yeniPoz = new Vector3(transform.position.x, .23f,transform.position.z);

            GameObject.FindWithTag("GameManager").GetComponent<GameManeger>().YokolmaEfektiOlustur(yeniPoz);
            gameObject.SetActive(false);

        }
        if (other.CompareTag("Testere"))

        {
            Vector3 yeniPoz = new Vector3(transform.position.x, .23f, transform.position.z);

            GameObject.FindWithTag("GameManager").GetComponent<GameManeger>().YokolmaEfektiOlustur(yeniPoz);
            gameObject.SetActive(false);

        }

        if (other.CompareTag("Pervaneigneler"))

        {
            Vector3 yeniPoz = new Vector3(transform.position.x, .23f, transform.position.z);

            GameObject.FindWithTag("GameManager").GetComponent<GameManeger>().YokolmaEfektiOlustur(yeniPoz);
            gameObject.SetActive(false);

        }


    }

}

