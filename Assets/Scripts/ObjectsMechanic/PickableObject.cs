using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PickableObject : MonoBehaviour
{
    [SerializeField] private float _shrinkedSize = 0.3f, _normalSize = 1f, _scaleSpeed = 0.1f;
    public bool IsCollected = false;
    public void Shrink()
    {
        transform.DOScale(_shrinkedSize, _scaleSpeed);
    }

    public void BackToNormalSize()
    {
        transform.DOScale(_normalSize, _scaleSpeed);
    }
}
