using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Dusman : MonoBehaviour
{
   public GameObject Saldiri_Hedefi;
    NavMeshAgent _Navmesh;
    bool Saldiri_Basladimi;
    void Start()
    {
        _Navmesh = GetComponent<NavMeshAgent>();
    }

    public void AnimasyonTetikle()
    {
        GetComponent<Animator>().SetBool("Saldiri", true);
        Saldiri_Basladimi = true;
    }
    // Update is called once per frame
    void Update()
    {
        if(Saldiri_Basladimi)
        _Navmesh.SetDestination(Saldiri_Hedefi.transform.position);
    }
}
