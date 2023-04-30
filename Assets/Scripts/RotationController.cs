using UnityEngine;

public class RotationController : MonoBehaviour
{
    /// <summary>
    /// Ограничения по вращению персонажа вверх/вниз
    /// </summary>
    [SerializeField]
    private float _minY = -60;
    [SerializeField]
    private float _maxY = 60;

    private float _moveX;
    private float _moveY;

    private void Awake()
    {
        // Прячем курсор.
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {
        // Получаем движение мыши по оси X:
        _moveX += Input.GetAxis("Mouse X");

        // Получаем движение мыши по оси Y:
        // Тут берем значение с минусом, так как в Unity при вращении вниз по оси X угол увеличивается, вверх - уменьшается,
        // а при получении Input.GetAxis("Mouse Y") - наоборот, вниз - уменьшается, вверх - увеличивается:
        _moveY -= Input.GetAxis("Mouse Y");
        
        // Не даем углу поворота по Y быть больше или меньше заданных.
        _moveY = Mathf.Clamp(_moveY, _minY, _maxY);

        // Вращаем персонажа.
        transform.rotation = Quaternion.Euler(_moveY, _moveX, 0);
    }
}