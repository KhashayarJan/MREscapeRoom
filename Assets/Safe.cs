using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class Safe : MonoBehaviour
{
    public List<Hole> Holes;

    [FormerlySerializedAs("Door")] public GameObject doorGO;

    public float doorOpenRotation;
    public float doorOpenDuration;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void CheckForHoles()
    {
        Debug.LogError("Checking for Holes");
        foreach (var hole in Holes)
        {
            if (hole.solved == false)
            {
                Debug.LogError("Hole: " + hole.name  + "is notSolved");
                return;
            }
        }
        SolvedSafe();
    }

    // Update is called once per frame
    void SolvedSafe()
    {
        doorGO.transform.DOLocalRotate(new Vector3( doorGO.transform.localRotation.eulerAngles.x, doorOpenRotation, doorGO.transform.localRotation.eulerAngles.z), doorOpenDuration);
        OnSolved?.Invoke();
    }

    public UnityEvent OnSolved;
}
