using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipsCreator : Creator<Spaceship>
{
    [SerializeField] private Spaceship _prefab;
    [SerializeField] private ObjectPool<SpaceshipBullet> _objectPoolToUse;

    public override Spaceship Create(Transform parent)
    {
        Spaceship ship;

        if (parent != null)
        {
            ship = Instantiate(_prefab, parent);
        }
        else
        {
            ship = Instantiate(_prefab);
        }

        ship.GetComponent<Gun>().pool = _objectPoolToUse;

        return ship;
    }
}
