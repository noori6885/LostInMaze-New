using UnityEngine;
using Unity.Cinemachine;

public class GunController : MonoBehaviour
{
    [Header("References")]
    public Camera playerCamera;
    public CinemachineCamera virtualCamera;

    [Header("UI")]
    public GameObject aimCrosshair;

    [Header("Gun Settings")]
    public float range = 100f;
    public int damage = 25;

    [Header("Zoom Settings")]
    public float normalFOV = 40f;
    public float zoomFOV = 20f;
    public float zoomSpeed = 15f;

    private AudioSource gunAudio;
    private ParticleSystem[] muzzleFlash;

    void Start()
    {
        if (playerCamera == null)
            playerCamera = Camera.main;

        gunAudio = GetComponent<AudioSource>();
        muzzleFlash = GetComponentsInChildren<ParticleSystem>();

        if (virtualCamera != null)
            virtualCamera.Lens.FieldOfView = normalFOV;

        if (aimCrosshair != null)
            aimCrosshair.SetActive(false);
    }

    void Update()
    {
        HandleZoom();

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void HandleZoom()
    {
        if (virtualCamera == null)
            return;

        bool aiming = Input.GetMouseButton(1);

        float targetFOV = aiming ? zoomFOV : normalFOV;

        virtualCamera.Lens.FieldOfView = Mathf.Lerp(
            virtualCamera.Lens.FieldOfView,
            targetFOV,
            Time.deltaTime * zoomSpeed
        );

        if (aimCrosshair != null)
            aimCrosshair.SetActive(aiming);
    }

    void Shoot()
    {
        if (gunAudio != null)
            gunAudio.Play();

        if (muzzleFlash != null)
        {
            foreach (ParticleSystem ps in muzzleFlash)
            {
                if (ps != null)
                    ps.Play();
            }
        }

        RaycastHit hit;

        if (Physics.Raycast(
            playerCamera.transform.position,
            playerCamera.transform.forward,
            out hit,
            range))
        {
            Debug.Log("Hit: " + hit.collider.name);

            ZombieHealth zombie = hit.collider.GetComponentInParent<ZombieHealth>();

            if (zombie != null)
            {
                zombie.TakeDamage(damage);
            }
        }
    }
}