using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AnaMenu_Manager : MonoBehaviour
{
    
    void Start()
    {
        
    }

    public void SahneYukle(int Index)
    {
        SceneManager.LoadScene(Index);
    }

    public void Oyna()
    {

    }
}
