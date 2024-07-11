using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float shopDetectionRange;
    Collider[] colliders;
    string[] colTag = {"Shop"};

    private void Update()
    {
        // OverlapSphere를 통해 주변에 있는 플레이어 체크
        colliders = Physics.OverlapSphere(transform.position, shopDetectionRange);

        foreach (Collider col in colliders)
        {
            if (col.CompareTag(colTag[0]) && Input.GetKeyDown(KeyCode.E))
            {
                Shop shop = col.GetComponent<Shop>();
                shop.Open();
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        // range에 해당하는 기즈모 시각화
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, shopDetectionRange);
    }
}
