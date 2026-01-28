using UnityEngine;

public class Platform : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float velocity = 1.5f;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position - new Vector3(0, 1f * Time.deltaTime, 0);
    }
}
