using UnityEngine;

public class GameObjectsManager : Static<GameObjectsManager>
{
    public Factory enemies;
    public Factory buildings;
    public Factory bullets;
    [Space]
    public Factory particleDamage;

    protected override void Awake()
    {
        base.Awake();
    }

    public void Prepare()
    {
        enemies.Initialize();
        buildings.Initialize();
        bullets.Initialize();

        particleDamage.Initialize();
    }

    public void SetParticleDamage(Vector3 position)
    {
        var particle = particleDamage.Get().GetComponent<ParticleDamage>();
        particle.Show(position);
    }
}
