using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Stat
{
    public float speed;
    public int hp;
    public int maxHp;
    public float force;

    public void CopyData(Stat copyData)
    {
        speed = copyData.speed;
        hp = copyData.hp;
        maxHp = copyData.maxHp;
        force = copyData.force;
    }
}
public class BaseStat : MonoBehaviour
{
    [SerializeField] protected Stat _orignStatData;
    [SerializeField] protected Stat _currentStat;

    public int Hp { get { return _currentStat.hp; } }
    public float Speed { get { return _currentStat.speed;} }
    public float Force { get { return _currentStat.force;} }

}
