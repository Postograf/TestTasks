using UnityEngine;

public class KeyboardControls : SpaceshipControls
{
    [SerializeField] private float _rotationPerClick;

    private void Update()
    {
        if (ship == null)
        {
            return;
        }

        var rotationCoefficient = Input.GetAxisRaw("Horizontal");

        if (rotationCoefficient != 0)
        {
            ship.Rotate(_rotationPerClick * (rotationCoefficient < 0 ? -1 : 1));
        }

        var vertical = Input.GetAxisRaw("Vertical");

        if (vertical > 0)
        {
            ship.Move();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ship.Shoot();
        }
    }
}
