using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class SpaceshipBullet : Bullet
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Asteroid asteroid))
        {
            asteroid.Split();
            Destroy();
        }
        else if (collision.TryGetComponent(out UFO ufo))
        {
            ufo.Destroy();
            Destroy();
        }
    }
}