using System;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public float Hp;
    public float MaxHp { get; protected set; }
    public float Speed { get; protected set; }
    public float Force { get; protected set; }

    protected Rigidbody rb;
    protected Player player;

    protected virtual void Start()
    {
        player = FindObjectOfType<Player>();
        rb = GetComponent<Rigidbody>();
        Hp = MaxHp;
    }

    public void Update()
    {
        Move();
    }

    public virtual void TakeDamage(float damage)
    {
        Hp -= damage;
        if (Hp <= 0)
            Die();
    }

    public abstract void Move();

    protected void Die()
    {
        Debug.Log($"{name} has died.");
        Destroy(gameObject);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            Destroy(other.gameObject);
            TakeDamage(player.force); 
        }
        else if (other.CompareTag("Player") || other.CompareTag("Border"))
        {
            Die();
        }
    }
}