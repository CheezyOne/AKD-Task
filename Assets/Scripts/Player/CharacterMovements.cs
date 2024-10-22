using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMovements : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _gravity = 9.81f; // �������� �������
    private CharacterController _controller;
    private Vector3 _velocity; // �������� ���������

    // ������ �� ������ ������
    [SerializeField] private Transform _head;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // �������� ����������� �������
        Vector3 forward = _head.forward; // ����������� �������
        Vector3 right = _head.right; // ����������� ������

        // �������� ���� � ����������
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        // ��������� �������� ������������ �������, �������� ������������ ���
        Vector3 inputMovement = (forward * verticalInput + right * horizontalInput).normalized;
        inputMovement.y = 0; // ������� ������� ������������ ���

        // ���������, ���� �� ����
        if (inputMovement != Vector3.zero)
        {
            // ������� ���������
            _velocity = new Vector3(inputMovement.x * _speed, _velocity.y, inputMovement.z * _speed);
        }
        else
        {
            // ���� ��� �����, ������������� ���������
            _velocity = new Vector3(0, _velocity.y, 0);
        }

        // ��������� ����������
        if (!_controller.isGrounded)
        {
            _velocity.y -= _gravity * Time.deltaTime;
        }
        else
        {
            _velocity.y = 0;
        }

        // ������� ���������
        _controller.Move(_velocity * Time.deltaTime);
    }
}