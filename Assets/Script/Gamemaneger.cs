using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemaneger : MonoBehaviour
{
    public GameObject Hedef;
    public GameObject prefabKarakter;
    public GameObject DogmaNoktas�;
    public GameObject VarisNoktasi;


    public List<GameObject> Karakterler;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))

           foreach (var item in Karakterler)
        {

               if (!item.activeInHierarchy)
                {
                   
                    item.transform.position = DogmaNoktas�.transform.position;
                    item.SetActive(true);
                    break;

                }


        }
    }
}
