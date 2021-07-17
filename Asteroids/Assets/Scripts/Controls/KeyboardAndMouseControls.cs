using UnityEngine;

public class KeyboardAndMouseControls : SpaceshipControls
{
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (ship == null)
        {
            return;
        }

        var mouseWorldPosition = _camera.ScreenToWorldPoint(Input.mousePosition);

        ship.RotateTo(mouseWorldPosition);

        var vertical = Input.GetAxisRaw("Vertical");

        if (vertical > 0)
        {
            ship.Move();
        }

        if (Input.GetButtonDown("Shoot"))
        {
            ship.Shoot();
        }
    }
}
