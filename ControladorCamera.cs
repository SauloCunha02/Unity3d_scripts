using UnityEngine;

public class ControladorCamera : MonoBehaviour
{
    [SerializeField] private Transform jogadortransform;
   [SerializeField] private Vector3 offset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = jogadortransform.position + offset;
    
    }
}
