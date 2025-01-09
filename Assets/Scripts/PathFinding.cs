using UnityEngine;

public class PathFinding : MonoBehaviour
{
    string target_tag;
    Transform closest_target;
    SphereCollider attackRange;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target_tag = transform.tag == "Player" ? "Enemy" : "Player"; 
    }

    // Update is called once per frame
    void Update()
    {
    }
}
