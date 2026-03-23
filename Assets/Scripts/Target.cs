using Unity.VisualScripting;
using UnityEngine;

public class Target : MonoBehaviour
{
    void Start()
    {
        RandomizePosition();
    }

    public void Hit()
    {
        transform.position = TargetBounds.Instance.GetRandomPosition();

        // Debug things
        Debug.Log("Objet Hit: " + gameObject.name);
    }

    void RandomizePosition()
    {
        transform.position = TargetBounds.Instance.GetRandomPosition();
    }
}
