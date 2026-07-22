using UnityEngine;

public class Gun : MonoBehaviour
{
    public float range = 25f;

    public int damage = 25;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Ray ray = Camera.main.ViewportPointToRay(
            new Vector3(0.5f,0.5f,0));

        RaycastHit hit;

        if(Physics.Raycast(ray,out hit,range))
        {
            Debug.Log(hit.collider.name);

            ZombieHealth zombie =
                hit.collider.GetComponent<ZombieHealth>();

            if(zombie != null)
            {
                zombie.TakeDamage(damage);
            }
        }
    }
}