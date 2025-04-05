using UnityEngine;
using DG.Tweening;

public class Door : MonoBehaviour
{
    public float doorOpenRotation;
    public float doorOpenDuration;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Open()
    {
        transform.DOLocalRotate(new Vector3(transform.localRotation.eulerAngles.x, doorOpenRotation, transform.localRotation.eulerAngles.z), doorOpenDuration);
    }
    
}
