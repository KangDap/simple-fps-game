using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandgunFire : MonoBehaviour
{
    [Header("References")]
    [SerializeField] Camera playerCamera;
    [SerializeField] AudioSource gunFire;
    [SerializeField] GameObject handgun;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] BulletTracer bulletTracer;
    [SerializeField] Light muzzleLight;
    [SerializeField] HitsCounter hitsCounter;

    [Header("Shooting")]
    [SerializeField] Transform muzzlePoint;
    [SerializeField] float maxRange = 100f;
    [SerializeField] LayerMask hitLayers;
    [SerializeField] bool isFiring = false;

    void Start()
    {

    }
    void Update()
    {
        // Single click, of course it's a M9 not a full-auto weapon :D
        if(Mouse.current.leftButton.wasPressedThisFrame)
        {
            if(isFiring == false)
            {
                isFiring = true;
                StartCoroutine(FiringGun());
            }
        }
    }

    IEnumerator FiringGun()
    {
        gunFire.Play();

        if (muzzleFlash != null)
        {
            muzzleFlash.Play();
        }

        if (muzzleLight != null)
        {     
            muzzleLight.enabled = true;
        }

        Ray cameraRay = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        Vector3 startPoint = muzzlePoint.position;
        Vector3 endPoint;

        if (Physics.Raycast(cameraRay, out RaycastHit hit, maxRange, hitLayers))
        {
            endPoint = hit.point; 

            if(hitsCounter != null)
            {
                hitsCounter.addHit();
            }
        }
        else
        {
            endPoint = cameraRay.origin + cameraRay.direction * maxRange;
        }

        StartCoroutine(bulletTracer.FireTracer(startPoint, endPoint));

        handgun.GetComponent<Animator>().Play("HandgunFire");

        yield return new WaitForSeconds(0.05f);

        if (muzzleLight != null)
        {
            muzzleLight.enabled = false;
        }

        yield return new WaitForSeconds(0.45f);

        handgun.GetComponent<Animator>().Play("Idle");

        yield return new WaitForSeconds(0.1f);

        isFiring = false;
    }
}
