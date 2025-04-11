using System;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    public bool isKeyLamp;

    public Color Keycolor;
    public Color StartColor;

    float radiusForLerp;
    
    [SerializeField]
    MeshRenderer meshRenderer;

    public string materialColorName;
    
    
    
    private void Start()
    {
        if (meshRenderer == null)
            meshRenderer = GetComponent<MeshRenderer>();
        
        var material = meshRenderer.material;
        //material.SetColor("_LampColor", StartColor);
        material.SetColor(materialColorName, StartColor);
        
        meshRenderer.material = material;
        
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
        
        Color newColor = Color.Lerp(Keycolor, StartColor, distance / radiusForLerp);
        
        var material = meshRenderer.material;
        material.SetColor("_LampColor", newColor);
        meshRenderer.material = material;
    }

    private void OnTriggerEnter(Collider other)
    {
        radiusForLerp = Vector3.Distance(other.transform.position, transform.position);
    }

    private void OnTriggerExit(Collider other)
    {
        var material = meshRenderer.material;
        material.SetColor("_LampColor", StartColor);
        meshRenderer.material = material;
    }
}
