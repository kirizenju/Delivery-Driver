using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Color32 hasPackageColor= new Color32(1,1,1,1);
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] float destroyDelay=0.5f;
    bool hasPackage;
    SpriteRenderer spriteRenderer;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
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
            spriteRenderer.color= hasPackageColor;
            Destroy(other.gameObject, destroyDelay);
        }
        if (other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Delivered");
            spriteRenderer.color= noPackageColor;
            hasPackage = false;
        }
    }
}
