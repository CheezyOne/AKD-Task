using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMovements : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _gravity = 9.81f; // Скорость падения
    private CharacterController _controller;
    private Vector3 _velocity; // Скорость персонажа

    // Ссылка на объект головы
    [SerializeField] private Transform _head;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // Получаем направление взгляда
        Vector3 forward = _head.forward; // Направление взгляда
        Vector3 right = _head.right; // Направление вправо

        // Получаем ввод с клавиатуры
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        // Вычисляем движение относительно взгляда, исключая вертикальную ось
        Vector3 inputMovement = (forward * verticalInput + right * horizontalInput).normalized;
        inputMovement.y = 0; // Убираем влияние вертикальной оси

        // Проверяем, есть ли ввод
        if (inputMovement != Vector3.zero)
        {
            // Двигаем персонажа
            _velocity = new Vector3(inputMovement.x * _speed, _velocity.y, inputMovement.z * _speed);
        }
        else
        {
            // Если нет ввода, останавливаем персонажа
            _velocity = new Vector3(0, _velocity.y, 0);
        }

        // Применяем гравитацию
        if (!_controller.isGrounded)
        {
            _velocity.y -= _gravity * Time.deltaTime;
        }
        else
        {
            _velocity.y = 0;
        }

        // Двигаем персонажа
        _controller.Move(_velocity * Time.deltaTime);
    }
}