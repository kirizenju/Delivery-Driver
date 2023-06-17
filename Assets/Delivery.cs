using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float destroyDelay=0.5f;
    bool hasPackage;
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Ouch");
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Package" && !hasPackage)
        {
            Debug.Log("Pick up");
            hasPackage = true;
            Destroy(other.gameObject, destroyDelay);
        }
        if (other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Delivered");
            hasPackage = false;
        }
    }
}
