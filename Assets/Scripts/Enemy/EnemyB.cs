using UnityEngine;

public class EnemyB : Enemy
{
    protected override void Start()
    {
        MaxHp = 1;
        Speed = 7;
        Force = 20;
        base.Start();
    }

    public override void Move()
    {
        transform.Translate(Vector3.back * Speed * Time.deltaTime);
    }
}