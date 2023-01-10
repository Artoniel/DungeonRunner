
using UnityEngine;

public class CameraController : MonoBehaviour
{
   [SerializeField] Transform _target;
    
    private void Start() 
    {
        transform.parent = null;
    }
    void LateUpdate()
    {
        if (_target)
        {
            transform.position = _target.transform.position;
        }
        
    }
}
