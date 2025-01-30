using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public GameObject navmesh;

    void Awake()
    {
        navmesh.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
