using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleGun : Gun
{
    private bool _canShoot = true;

    public override bool Shoot()
    {
        if (_canShoot && pool.TryGetObject(out var bullet))
        {
            base.Shoot();

            bullet.transform.position = _shootPoint.position;
            bullet.transform.rotation = transform.rotation;

            bullet.gameObject.SetActive(true);

            bullet.Rigidbody.velocity = transform.up * _shootForce;

            StartCoroutine(WaitForDelay());
        }

        return _canShoot;
    }

    private IEnumerator WaitForDelay()
    {
        _canShoot = false;

        yield return new WaitForSeconds(_shootDelay);

        _canShoot = true;
    }
}
