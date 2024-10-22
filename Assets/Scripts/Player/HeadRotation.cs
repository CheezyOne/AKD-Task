using UnityEngine;

public class HeadRotation : MonoBehaviour
{
    [SerializeField] private Transform _eye; 
    [SerializeField] private float _sensitivity = 2f;
    [SerializeField] private float _maxHeadAngle = 60f; 

    private float _rotationX = 0f; 

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * _sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * _sensitivity;

        _rotationX -= mouseY;
        _rotationX = Mathf.Clamp(_rotationX, -_maxHeadAngle, _maxHeadAngle);

        _eye.localRotation = Quaternion.Euler(_rotationX, _eye.localEulerAngles.y + mouseX, 0);
    }
}
