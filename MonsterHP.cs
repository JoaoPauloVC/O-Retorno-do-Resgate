using UnityEngine;

public class MonsterHP : MonoBehaviour
{
    public float HitPoints;
    public float MaxHitPoints;

    void Start()
    {
        HitPoints = MaxHitPoints;
    }

    public void TakeHit(float damage)
    {
        HitPoints -= damage;

        if (HitPoints <= 0)
            Destroy(gameObject);
    }
}
