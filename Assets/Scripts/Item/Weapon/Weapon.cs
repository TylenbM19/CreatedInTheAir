using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected Arrow Arrow;
    [SerializeField] protected Transform shootPoint;

    public abstract void Shoot();
}
