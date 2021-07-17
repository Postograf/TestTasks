using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GridLayoutGroup), typeof(RectTransform))]
public class HealthView : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Image _healthImagePrefab;

    private Stack<Image> _healthImages = new Stack<Image>();

    private void OnEnable()
    {
        _health.HealthDecreased += OnHealthDecrease;
        _health.Initialized += OnInitialization;
    }

    private void OnInitialization(int value)
    {
        var layoutGroup = GetComponent<GridLayoutGroup>();
        var transform = GetComponent<RectTransform>();
        layoutGroup.cellSize = new Vector2(transform.rect.width / value, layoutGroup.cellSize.y);

        for (var i = 0; i < value; i++)
        {
            _healthImages.Push(Instantiate(_healthImagePrefab, transform));
        }
    }

    private void OnHealthDecrease()
    {
        var image = _healthImages.Pop();

        if (image != null)
        {
            Destroy(image.gameObject);
        }
    }

    private void OnDisable()
    {
        _health.HealthDecreased -= OnHealthDecrease;
        _health.Initialized -= OnInitialization;
    }
}
