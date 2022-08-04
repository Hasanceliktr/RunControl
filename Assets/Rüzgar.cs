using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rüzgar : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("AltKarekterler"))
        {
            Debug.Log("Rüzgar alanına giriş yapıldı.");

            other.GetComponent<Rigidbody>().AddForce(new Vector3(-5, 0, 0), ForceMode.Impulse);
        }
    }
}
