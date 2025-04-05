using System;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    public Light pointLight;

    public bool isKeyLamp;

    public Color Keycolor;
    public Color StartColor;

    public float radiusForLerp;
    
    private void Start()
    {
        pointLight.color = StartColor;
        if (!isKeyLamp)
        {
            Destroy(GetComponent<SphereCollider>());
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Wand"))
        {
            Debug.LogError("Wand is not tagged wand!");
            return;
        }

        float distance = Vector3.Distance(other.transform.position, transform.position);
        pointLight.color = Color.Lerp(Keycolor, StartColor, distance / radiusForLerp);
    }

    private void OnTriggerEnter(Collider other)
    {
        radiusForLerp = Vector3.Distance(other.transform.position, transform.position);
    }

    private void OnTriggerExit(Collider other)
    {
        pointLight.color = StartColor;

    }
}
