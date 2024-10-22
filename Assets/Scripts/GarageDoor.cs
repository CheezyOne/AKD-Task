using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Sounds))]
public class GarageDoor : MonoBehaviour
{
    [SerializeField] private float _rotateDegree, _rotateTime = 1f;
    [SerializeField] private Transform _leftDoor, _rightDoor;
    private void Start()
    {
        GetComponent<Sounds>().PlaySound(0);
        _leftDoor.DORotate(Vector3.up * _rotateDegree, _rotateTime);
        _rightDoor.DORotate(Vector3.up * -_rotateDegree, _rotateTime);
    }
}
