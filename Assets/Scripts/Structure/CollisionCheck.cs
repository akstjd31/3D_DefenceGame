using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    public Material unsafeMat, safeMat;
    [SerializeField] private Material originMat;
    public float objectRange;
    public bool isOverlap = false;
    public bool isPlaced = false;

    private void Awake()
    {
        originMat = this.GetComponent<MeshRenderer>().material;
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
            if (col.tag.Equals("Shop"))
            {
                this.GetComponent<MeshRenderer>().material = unsafeMat;
                isOverlap = true;
            }
            else
            {
                this.GetComponent<MeshRenderer>().material = safeMat;
                isOverlap = false;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        // range에 해당하는 기즈모 시각화
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, objectRange);
    }
}
