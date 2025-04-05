using UnityEngine;
using UnityEngine.Events;

public class Key : MonoBehaviour
{

    public Hole.KeyShapes keyShape;
    public GameObject grabInteraction;

    public void SnapToHole(Hole hole)
    {
        print("SNAP!");
        Destroy(grabInteraction);
        transform.SetParent(hole.placementHole);
        transform.localPosition = Vector3.zero;
        transform.localEulerAngles = new Vector3(hole.requiredRotation, 0, 0);
        OnSnapped?.Invoke();
        
        GetComponent<Collider>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
    }

    public UnityEvent OnSnapped;

}
