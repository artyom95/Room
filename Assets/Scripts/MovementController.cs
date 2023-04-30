using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] 
    private float _speed = 5f;
    private CharacterController _characterController;
    
    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // Получаем пользовательский ввод.
        var verticalInput = Input.GetAxis("Vertical");
        var horizontalInput = Input.GetAxis("Horizontal");
    
        // Вычисляем вектор направления.
        var inputDirection = new Vector3(horizontalInput, 0, verticalInput);
        // Конвертируем локальное направление персонажа вперед в мировое.
        var direction = transform.TransformDirection(inputDirection);

        // Перемещаем персонажа.
        _characterController.SimpleMove(direction * _speed);
    }
}