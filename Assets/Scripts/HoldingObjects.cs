using TMPro;
using UnityEngine;

public class HoldingObjects : MonoBehaviour
{
    [SerializeField] private float _dropForce, _pickUpDistance;
    [SerializeField] private Transform _holdingPosition;
    private bool _isHoldingObject = false;
    private PickableObject _pickedObject;
    private Rigidbody _objectRB;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!_isHoldingObject)
                TryToPickUpObject();
            else
                DropObject();
            if (_isHoldingObject)
            {
                _pickedObject.transform.position = _holdingPosition.position;
            }
        }
    }
    private void TryToPickUpObject()
    {
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, _pickUpDistance))
        {
            if (hit.collider.TryGetComponent<PickableObject>(out PickableObject pickableObject))
            {
                _pickedObject = pickableObject;
                _isHoldingObject = true;
                _objectRB = _pickedObject.GetComponent<Rigidbody>();
                _objectRB.isKinematic = true;
                _pickedObject.Shrink();
            }
        }
    }

    private void DropObject()
    {
        _pickedObject.BackToNormalSize();
        _objectRB.isKinematic = false;
        _objectRB.AddForce(transform.forward * _dropForce, ForceMode.Impulse);
        _isHoldingObject = false;
        _pickedObject = null;
    }
}