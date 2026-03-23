using UnityEngine;
using UnityEngine.InputSystem;

public class TargetController : MonoBehaviour
{
    [SerializeField] private Camera cam;

    void Update()
    {
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));

            if(Physics.Raycast(ray, out RaycastHit hit))
            {
                Target target = hit.collider.gameObject.GetComponent<Target>();
                if(target != null)
                {
                    target.Hit();
                }
            }
        }
    }
}
