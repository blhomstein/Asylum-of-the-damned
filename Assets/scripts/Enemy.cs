using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float health;
    [SerializeField] protected float speed;
    [SerializeField] protected string illness;

    void Attack() { }
    void Follow() { }
    void LookFor() { }
    void Timer() { }

}
