using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform cameraHolder;
    [SerializeField] private float mouseSensitivity = 0.1f;
    private float verticalLookRotation;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if(Mouse.current == null)
        {
            return;
        }

        float mouseX = Mouse.current.delta.x.ReadValue() * mouseSensitivity;
        float mouseY = Mouse.current.delta.y.ReadValue() * mouseSensitivity;

        transform.Rotate(Vector3.up * mouseX);

        verticalLookRotation -= mouseY;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);

        cameraHolder.localEulerAngles = new Vector3(verticalLookRotation, 0f, 0f);
    }
}