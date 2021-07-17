using UnityEngine;

public class SpaceshipsCreator : Creator<Spaceship>
{
    [SerializeField] private Spaceship _prefab;
    [SerializeField] private ObjectPool<SpaceshipBullet> _objectPoolToUse;

    public override Spaceship Create(Transform parent)
    {
        var ship = parent != null ? Instantiate(_prefab, parent) : Instantiate(_prefab);

        ship.GetComponent<Gun>().pool = _objectPoolToUse;

        return ship;
    }
}
