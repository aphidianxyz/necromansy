using UnityEngine;

public class GenProjectile : MonoBehaviour
{
    public Transform target = null;
    private bool hadTarget = false;

    public float projectileSpeed = 5;

    public float projectileDamage = 2;

    public float minDistance = 0.5f;

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            //Generate a unit vector and move along that vector towards target
            Vector3 moveDirNormalized = (target.position - transform.position).normalized;
            transform.position += moveDirNormalized * projectileSpeed;
            
            //Manually handles collisions
            if (Vector3.Distance(target.transform.position, transform.position) < minDistance)
            {
                Destroy(gameObject);
                target.gameObject.GetComponent<unitStats>().TakeDamage(projectileDamage);
            }
        }
        //Handles target dying mid flight
        else if (hadTarget)
        {
            Destroy(gameObject);
        }

    }

    public void SetTarget(Transform target)
    {
        this.target = target;
        hadTarget = true;
    }
}
