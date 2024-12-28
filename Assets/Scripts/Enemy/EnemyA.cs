using UnityEngine;

public class EnemyA : Enemy
{
    protected override void Start()
    {
        MaxHp = 3;
        Speed = 4;
        Force = 5;
        base.Start();
    }

    public override void Move()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        rb.MovePosition(transform.position + direction * Speed * Time.deltaTime);
    }
}