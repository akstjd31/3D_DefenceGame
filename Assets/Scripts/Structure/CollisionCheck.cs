using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    public bool isCollisionShop = false;

    private void OnCollisionEnter(Collision col)
    {
        if (col.collider.CompareTag("Shop"))
        {
            isCollisionShop = true;
        }
    }

    private void OnCollisionExit(Collision col)
    {
        if (col.collider.CompareTag("Shop"))
        {
            isCollisionShop = false;
        }
    }
}
