using System;
using UnityEngine;

public class PickupTrunk : MonoBehaviour
{
    public static Action onObjectPlacedIn, onObjectTakenOut;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PickableObject>() != null)
        {
            other.GetComponent<PickableObject>().IsCollected = true;
            onObjectPlacedIn?.Invoke();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PickableObject>() != null)
        {
            other.GetComponent<PickableObject>().IsCollected = false;
            onObjectTakenOut?.Invoke();
        }
    }
}
