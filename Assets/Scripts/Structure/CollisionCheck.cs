using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    private Transform player;
    public Material unsafeMat, safeMat;
    [SerializeField] private Material originMat;
    public float objectRange;
    public bool isSafetyZone = false;
    public bool isPlaced = false;

    private void Awake()
    {
        originMat = this.GetComponent<MeshRenderer>().material;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (!isPlaced)
            OverlapCheck();
    }

    public void SetOriginMaterial()
    {
        this.GetComponent<MeshRenderer>().material = originMat;
    }

    private void OverlapCheck()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, objectRange);

        foreach (Collider col in colliders)
        {
            if (col.transform != this.transform)
            {
                if (col.tag.Equals("Shop") || col.tag.Equals("Object") || col.tag.Equals("Player"))
                {
                    this.GetComponent<MeshRenderer>().material = unsafeMat;
                    isSafetyZone = false;
                }
                else
                {
                    if (IsPlayerNearby(5.0f))
                    {
                        this.GetComponent<MeshRenderer>().material = safeMat;
                        isSafetyZone = true;
                    }
                    else
                    {
                        this.GetComponent<MeshRenderer>().material = unsafeMat;
                        isSafetyZone = false;
                    }
                }
            }
        }
    }

    private bool IsPlayerNearby(float dist)
    {
        return Vector3.Distance(this.transform.position, player.transform.position) <= dist;
    }

    private void OnDrawGizmosSelected()
    {
        // range에 해당하는 기즈모 시각화
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, objectRange);
    }
}
