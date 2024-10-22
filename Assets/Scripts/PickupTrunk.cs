using System;
using UnityEngine;

public class PickupTrunk : MonoBehaviour
{
    public static Action onObjectPlacedIn, onObjectTakenOut;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PickableObject>() != null)
            onObjectPlacedIn?.Invoke();
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PickableObject>() != null)
            onObjectTakenOut?.Invoke();
    }
}
