using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Player player))
        {
        }
    }
}
