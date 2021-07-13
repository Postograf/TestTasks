using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOBullet : Bullet
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Spaceship spaceship))
        {
            Destroy(spaceship.gameObject);
            Destroy();
        }
    }
}
