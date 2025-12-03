using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    public float delay = 1.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, delay);

    }

}