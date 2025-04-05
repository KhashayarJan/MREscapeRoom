using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;

public class Hole : MonoBehaviour
{
    public float requiredRotation;
    public float marginOfError = 5f;
    public KeyShapes keyShapeRequired;

    public Transform placementHole;
    
    public ParticleSystem particleSystem;
    
    public bool solved = false;

    private void OnTriggerStay(Collider other)
    {
        if (solved)
            return;
        if (other.CompareTag("Key"))
        {
            var key = other.gameObject.GetComponent<Key>();
            if (key == null || key.keyShape != keyShapeRequired)
                return;
            
            if (other.transform.localEulerAngles.x <= requiredRotation + marginOfError
                && other.transform.localEulerAngles.x >= requiredRotation - marginOfError)
            {
                key.SnapToHole(this);
                solved = true;
                OnSnapped?.Invoke();
            }
        }
    }

    private void Start()
    {
        particleSystem.GetComponent<Renderer>().material = GetComponent<MeshRenderer>().material;
    }

    private void OnValidate()
    {
        requiredRotation = transform.rotation.eulerAngles.x;
    }

    public UnityEvent OnSnapped;
    public enum KeyShapes
    {
        Shape1,
        Shape2,
        Shape3,
        Shape4
    }
}
