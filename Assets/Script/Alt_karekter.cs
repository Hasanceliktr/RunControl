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
        Target = GameObject.FindWithTag("GameManager").GetComponent<Gamemaneger>().VarisNoktasi;
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
            GameObject.FindWithTag("GameManager").GetComponent<Gamemaneger>().AnlikKarakterSayisi--;
            gameObject.SetActive(false);

        }

    }


}

