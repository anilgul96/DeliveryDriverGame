using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);
    bool hasPackage;

    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    [SerializeField] float DestroyDelay = 0.5f;

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Oh bumped in!");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("What happened??");
        if (other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package picked up");
            hasPackage = true;
            Destroy(other.gameObject, DestroyDelay);
            spriteRenderer.color = hasPackageColor;

        }

        if (other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Package Delivered");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
    }
}
