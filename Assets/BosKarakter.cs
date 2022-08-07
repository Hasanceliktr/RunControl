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
    private void LateUpdate()
    {
        if(Temasvar)
        _NavMesh.SetDestination(Target.transform.position);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("AltKarekterler") || other.CompareTag("Player"))
        {
            MaterialDegistirveAnimasyonTetikle();
            Temasvar = true;
        }

    }

    void MaterialDegistirveAnimasyonTetikle()
    {
        Material[] mats = _Renderer.materials;
        mats[0] = AtanacakOlanMateryal;
        _Renderer.materials = mats;
        _Animator.SetBool("Saldir",true);


    }

}
