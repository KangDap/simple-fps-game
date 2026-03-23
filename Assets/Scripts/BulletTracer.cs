using System.Collections;
using UnityEngine;

public class BulletTracer : MonoBehaviour
{
    [Header("Tracer Settings")]
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] float bulletSpeed = 500f;
    [SerializeField] float tracerDuration = 0.01f;

    public IEnumerator FireTracer(Vector3 startPoint, Vector3 endPoint)
    {
        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, startPoint); 
        lineRenderer.SetPosition(1, startPoint); 

        float distance = Vector3.Distance(startPoint, endPoint);
        float travelTime = distance / bulletSpeed;
        float elapsed = 0f;

        while (elapsed < travelTime)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / travelTime);
            Vector3 currentPos = Vector3.Lerp(startPoint, endPoint, t);
            lineRenderer.SetPosition(1, currentPos);
            yield return null;
        }

        lineRenderer.SetPosition(1, endPoint);

        yield return new WaitForSeconds(tracerDuration);
        lineRenderer.enabled = false;
    }
}
