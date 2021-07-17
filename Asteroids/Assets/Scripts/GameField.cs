using UnityEngine;

public class GameField : MonoBehaviour
{
    [SerializeField] private Transform _container;

    private Camera _camera;
    private Vector2 _maxPoint;
    private Vector2 _minPoint;

    private void Start()
    {
        _camera = Camera.main;

        _maxPoint = _camera.ViewportToWorldPoint(new Vector2(1, 1));
        _minPoint = _camera.ViewportToWorldPoint(new Vector2(0, 0));
    }

    private void LateUpdate()
    {
        for (var i = 0; i < _container.childCount; i++)
        {
            var screenObject = _container.GetChild(i);

            if (!screenObject.gameObject.activeSelf)
            {
                continue;
            }

            var position = screenObject.position;

            position.x = InversedClamp(position.x, _minPoint.x, _maxPoint.x);
            position.y = InversedClamp(position.y, _minPoint.y, _maxPoint.y);

            screenObject.position = position;
        }
    }

    private float InversedClamp(float value, float min, float max)
    {
        if (value > max)
        {
            return min;
        }
        
        if (value < min)
        {
            return max;
        }

        return value;
    }
}
