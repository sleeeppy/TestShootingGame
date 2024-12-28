using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ObjectManager
{
    public Bullet CreateProjectile(string name, bool isPlayer = false)
    {
        GameObject prefab = Resources.Load<GameObject>($"Prefab/Bullet/{name}");
        GameObject gameObject = Object.Instantiate(prefab);
        
        Bullet bullet = gameObject.GetComponent<Bullet>();

        return bullet;
    }
}
