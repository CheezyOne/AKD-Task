using UnityEngine;

public class HoldingObjects : MonoBehaviour
{
    [SerializeField] private float _dropForce;
    private bool _isHoldingObject = false;
    private PickableObject _pickedObject;
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (!_isHoldingObject)
                TryToPickUpObject();
            else
                DropObject();
        }
    }
    private void TryToPickUpObject()
    {

    }
    private void DropObject()
    {

    }
}
