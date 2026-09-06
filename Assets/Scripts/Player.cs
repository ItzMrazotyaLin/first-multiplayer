using Unity.VisualScripting;
using UnityEngine.InputSystem;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int speed = 7;

    void Update()
    {
        Vector2 inputDirection = Vector2.zero;

        // Проверяем, существует ли клавиатура
        if (Keyboard.current != null)
        {
            // Считываем нажатия клавиш WASD или стрелок
            if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed) inputDirection.y = 1f;
            if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed) inputDirection.y = -1f;
            if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed) inputDirection.x = -1f;
            if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed) inputDirection.x = 1f;
        }

        // Нормализуем вектор, чтобы персонаж не двигался быстрее по диагонали
        if (inputDirection.magnitude > 1f)
        {
            inputDirection.Normalize();
        }

        // Переводим 2D ввод в 3D пространство (X - влево/вправо, Z - вперед/назад)
        Vector3 moveMovement = new Vector3(inputDirection.x, 0f, inputDirection.y);

        // Двигаем объект в мировых координатах
        transform.Translate(moveMovement * speed * Time.deltaTime, Space.World);
    }
}