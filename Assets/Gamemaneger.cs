using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemaneger : MonoBehaviour
{
    public GameObject Hedef;
    public GameObject prefabKarakter;
    public GameObject DogmaNoktasý;
    public GameObject VarisNoktasi;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            Instantiate(prefabKarakter, DogmaNoktasý.transform.position, Quaternion.identity);
        {

        }
    }
}
