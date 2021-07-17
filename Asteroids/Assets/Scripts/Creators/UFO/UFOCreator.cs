using UnityEngine;

public class UFOCreator : Creator<UFO>
{
    [SerializeField] private UFO _prefab;
    [SerializeField] private ObjectPool<UFOBullet> _objectPoolToUse;
    [SerializeField] private SpaceshipSpawner _spaceshipSpawner;

    public override UFO Create(Transform parent)
    {
        var ufo = parent != null ? Instantiate(_prefab, parent) : Instantiate(_prefab);

        ufo.pool = _objectPoolToUse;
        ufo.spaceshipSpawner = _spaceshipSpawner;

        return ufo;
    }
}
