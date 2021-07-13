using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOCreator : Creator<UFO>
{
    [SerializeField] private UFO _prefab;
    [SerializeField] private ObjectPool<UFOBullet> _objectPoolToUse;
    [SerializeField] private SpaceshipSpawner _spaceshipSpawner;

    public override UFO Create(Transform parent)
    {
        UFO ufo;

        if (parent != null)
        {
            ufo = Instantiate(_prefab, parent);
        }
        else
        {
            ufo = Instantiate(_prefab);
        }

        ufo.pool = _objectPoolToUse;
        ufo.spaceshipSpawner = _spaceshipSpawner;

        return ufo;
    }
}
