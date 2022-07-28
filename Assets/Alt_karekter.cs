using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Alt_karekter : MonoBehaviour
{
    GameObject target;
    NavMeshAgent _NavMesh;
    void Start()
    {
        _NavMesh = GetComponent<NavMeshAgent>();
        target = GameObject.FindWithTag("GameManager").GetComponent<Gamemaneger>().VarisNoktasi;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        _NavMesh.SetDestination(target.transform.position);
    }
}
