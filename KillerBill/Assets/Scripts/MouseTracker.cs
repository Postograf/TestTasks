using UnityEngine;

public class MouseTracker : MonoBehaviour
{
    [SerializeField] private Transform _spine;
    [SerializeField] private float _angle;

    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void LateUpdate()
    {
        var cameraRay = _camera.ScreenPointToRay(Input.mousePosition);
        var groundPlane = new Plane(Vector3.up, Vector3.zero);
        
        if (groundPlane.Raycast(cameraRay, out float length))
        {
            var mouseDirection = (cameraRay.GetPoint(length) - transform.position).normalized;
            
            var spineDirection = _spine.up;
            spineDirection.y = 0;
            spineDirection.Normalize();
            
            var angle = Vector3.Angle(spineDirection, mouseDirection);

            var d = mouseDirection.x * spineDirection.z - spineDirection.x * mouseDirection.z; 
            var sign = d < 0 ? -1 : 1;
            
            var eulerRotation = _spine.eulerAngles;
            
            _spine.rotation = Quaternion.Euler(
                eulerRotation.x, 
                eulerRotation.y + sign * angle, 
                eulerRotation.z
            );
        }
    }
}
