public class AsteroidsDependentPool : DependentPool<Asteroid, Asteroid>
{
    protected override void OnObjectsAdded(int count)
    {
        Add(count * Asteroid.fragmentsCount);
    }
}
