using UnityEngine;

public class MouseTracker : MonoBehaviour
{
    [SerializeField] private Transform _spine;

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
            var mouseDirection = cameraRay.GetPoint(length);

            mouseDirection.x -= _spine.up.y / 2;
            mouseDirection.z -= _spine.up.y / 2;
            mouseDirection.y = _spine.up.y;

            var angle = Vector3.Angle(_spine.up, mouseDirection);

            var sign = _spine.up.x * mouseDirection.y - mouseDirection.x * _spine.up.y < 0 ? -1 : 1;

            var eulerRotation = _spine.eulerAngles;
            _spine.rotation = Quaternion.Euler(eulerRotation.x, eulerRotation.y + sign * angle, eulerRotation.z);
        }
    }
}