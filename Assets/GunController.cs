using UnityEngine;

public class GunController : MonoBehaviour
{
    [Header("References")]
    public Camera playerCamera;
    public Transform gunTransform;
    public ParticleSystem muzzleFlash;

public AudioSource audioSource;
public AudioClip fireSound;


    [Header("Gun Settings")]
    public float fireRange = 100f;
    public int damage = 25;

    [Header("Camera Aim")]
    public float normalFOV = 60f;
    public float aimFOV = 35f;
    public float aimSpeed = 8f;

    [Header("Gun Aim")]
    public Vector3 normalPosition = new Vector3(0.25f, -0.25f, 0.40f);
    public Vector3 aimPosition = new Vector3(0.05f, -0.12f, 0.20f);
    public float gunMoveSpeed = 10f;

    void Start()
    {
        if (playerCamera == null)
            playerCamera = Camera.main;

        if (gunTransform != null)
            gunTransform.localPosition = normalPosition;

        if (muzzleFlash != null)
        {
            muzzleFlash.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            muzzleFlash.Clear();
        }
    }

    void Update()
    {
        // Left Click = Fire
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        // Right Click = Aim
        if (Input.GetMouseButton(1))
        {
            playerCamera.fieldOfView = Mathf.Lerp(
                playerCamera.fieldOfView,
                aimFOV,
                Time.deltaTime * aimSpeed);

            if (gunTransform != null)
            {
                gunTransform.localPosition = Vector3.Lerp(
                    gunTransform.localPosition,
                    aimPosition,
                    Time.deltaTime * gunMoveSpeed);
            }
        }
        else
        {
            playerCamera.fieldOfView = Mathf.Lerp(
                playerCamera.fieldOfView,
                normalFOV,
                Time.deltaTime * aimSpeed);

            if (gunTransform != null)
            {
                gunTransform.localPosition = Vector3.Lerp(
                    gunTransform.localPosition,
                    normalPosition,
                    Time.deltaTime * gunMoveSpeed);
            }
        }
    }

    void Shoot(){

if (audioSource != null && fireSound != null)
{
    audioSource.PlayOneShot(fireSound);
}


    if (muzzleFlash != null)
    {
        muzzleFlash.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        muzzleFlash.Play();
    }

    RaycastHit hit;

    if (Physics.Raycast(playerCamera.transform.position,
                        playerCamera.transform.forward,
                        out hit,
                        fireRange))
    {
        ZombieHealth zombie = hit.collider.GetComponent<ZombieHealth>();

        if (zombie != null)
        {
            zombie.TakeDamage(damage);
        }
    }
}
}