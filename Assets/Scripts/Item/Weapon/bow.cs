using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : Weapon
{
    private bool _pressed;

    public override void Shoot()
    {
        Instantiate(Arrow, shootPoint.position, Quaternion.identity);
    }
}
