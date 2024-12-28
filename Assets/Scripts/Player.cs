using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public int hp
    {
        get => _hp;
        set
        {
            if (_hp != value)
            {
                _hp = value;
                UpdateHp();
            }
        }
    }
    
    private int _hp;
    
    [SerializeField] private int maxHp;
    [SerializeField] private float speed;
    [SerializeField] public float force;
    [SerializeField] private float fireDelay;
    
    private float fuel
    {
        get => _fuel;
        set
        {
            if (_fuel != value)
            {
                _fuel = value;
                UpdateFuelGauge();
            }
        }
    }
    
    private float _fuel;
    [SerializeField] private Slider fuelGauge;
    
    [SerializeField] private int level;
    [SerializeField] private Image[] hpImage;
    [SerializeField] private Transform firePos;

    private Rigidbody rb;
    
    private float curTime;

    private void Start()
    {
        Init();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
        Fire();
        
        curTime += Time.deltaTime;
        
        if (fuel == 0)
        {
            Die();
        }
    }

    void Init()
    {
        hp = 3;
        maxHp = 3;
        force = 1;
        level = 1;
        fuel = 1;
        fireDelay = 0.3f;
    }

    private void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        
        Vector3 curPos = transform.position;
        Vector3 nextPos = new Vector3(h, 0, v).normalized * speed * Time.deltaTime;

        transform.position = curPos + nextPos;
        
        if (h != 0 || v != 0)
        {
            fuel -= 0.1f * Time.deltaTime;
            fuel = Mathf.Max(fuel, 0);
        }
    }

    public void UpdateHp()
    {
        for (int i = 0; i < maxHp; i++)
        {
            hpImage[i].color = new Color(1, 1, 1, i < hp ? 1 : 0);
        }
    }

    public void UpdateFuelGauge()
    {
        fuelGauge.value = fuel;
    }

    private void Die()
    {
        Time.timeScale = 0;
        gameObject.SetActive(false);
    }
    
    private void Fire()
    {
        if (Input.GetKey(KeyCode.LeftControl) && curTime >= fireDelay)
        {
            curTime = 0; 
            
            Bullet bullet = Managers.Object.CreateProjectile("PlayerBullet", true);
            bullet.transform.position = firePos.position;
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy") || other.CompareTag("EnemyBullet"))
        {
            if(hp > 0)
                hp -= 1;
            else
            {
                Die();
            }
        }
        else if (other.CompareTag("Item"))
        {
            Iitem item = other.GetComponent<Iitem>();
            
            item?.Excute();
        }
    }
}
