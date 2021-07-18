using UnityEngine;

public class IdleState : MonoBehaviour
{
    [SerializeField] private Transform _spine;
    [SerializeField] private float _maxAngle = 90;

    private void Update()
    {
        var spineDirection = _spine.up;
        spineDirection.y = 0;
        spineDirection.Normalize();

        var angleBetweenDirections = Vector3.Angle(transform.forward, spineDirection);

        if (angleBetweenDirections > _maxAngle)
        {
            var d = spineDirection.x * transform.forward.z - transform.forward.x * spineDirection.z; 
            var sign = d < 0 ? -1 : 1;
            var rotateAngle = angleBetweenDirections - _maxAngle;
            
            transform.Rotate(new Vector3(0, sign * rotateAngle, 0));
        }
    }
}
