using UnityEngine;

[RequireComponent(typeof(Sounds))]
public class HoldingObjects : MonoBehaviour
{
    [SerializeField] private float _dropForce, _pickUpDistance;
    [SerializeField] private Transform _holdingPosition, _eyes;
    [SerializeField] private Camera _playerCamera;
    private bool _isHoldingObject = false;
    private PickableObject _pickedObject;
    private Rigidbody _objectRB;
    private Sounds _sounds => GetComponent<Sounds>();

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!_isHoldingObject)
                TryToPickUpObject();
            else
                DropObject();
        }

        if (_isHoldingObject)
        {
            _pickedObject.transform.position = _holdingPosition.position;
        }
    }

    private void TryToPickUpObject()
    {
        Ray ray = _playerCamera.ScreenPointToRay(Input.mousePosition);
        if (!Physics.Raycast(ray, out RaycastHit hit, _pickUpDistance))
        {
            return;
        }
        if (hit.collider.TryGetComponent<PickableObject>(out PickableObject pickableObject))
        {
            if (pickableObject.IsCollected)
                return;
            _sounds.PlaySound(0);
            _pickedObject = pickableObject;
            _isHoldingObject = true;
            _objectRB = _pickedObject.GetComponent<Rigidbody>();
            _objectRB.isKinematic = true;
            _pickedObject.GetComponent<Collider>().enabled = false;
            _pickedObject.Shrink();
        }
    }

    private void DropObject()
    {
        _sounds.PlaySound(1);
        _pickedObject.BackToNormalSize();
        _pickedObject.GetComponent<Collider>().enabled = true;
        _objectRB.isKinematic = false;
        _objectRB.AddForce(_eyes.forward * _dropForce, ForceMode.Impulse);
        _isHoldingObject = false;
        _pickedObject = null;
    }
}