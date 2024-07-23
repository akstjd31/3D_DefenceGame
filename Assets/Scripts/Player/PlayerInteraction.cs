using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    string[] colTag = { "Shop" };

    ////////////////////////////
    // Shop
    public float shopDetectionRange;

    /////////////////////////////
    // Quickslot, curItem
    QuickSlot quickSlot;
    [SerializeField] private GameObject curSlotItem;
    [SerializeField] private GameObject itemSpawner;
    public Camera playerCamera;      // 플레이어의 카메라
    public float maxRayDistance = 100f; // 레이캐스트 최대 거리
    public LayerMask groundMask, shopMask;  // 설치 가능한 레이어
    bool isGroundHit = false;

    private void Awake()
    {
        quickSlot = GameObject.FindGameObjectWithTag("Slots").GetComponent<QuickSlot>();
    }
    // if (itemSpawner != null)
    // {
    //     itemSpawner.transform.position = screenCenter;
    // }
    private void Update()
    {
        ShopDetection();

        curSlotItem = quickSlot.IsItemInSlot() ? quickSlot.GetSlotItem().prefab.gameObject : null;

        if (curSlotItem != null)
        {
            PlaceObject();
        }
        else
        {
            if (itemSpawner != null)
            {
                Destroy(itemSpawner);
            }
        }
    }

    void PlaceObject()
    {
        // 화면 중앙의 좌표
        Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);

        // 레이캐스트를 위한 변수
        Ray ray = playerCamera.ScreenPointToRay(screenCenter);
        RaycastHit hit;

        isGroundHit = Physics.Raycast(ray, out hit, maxRayDistance, groundMask);
        // 레이캐스트 발사
        if (isGroundHit)
        {
            if (itemSpawner == null)
            {
                itemSpawner = Instantiate(curSlotItem, Vector3.zero, Quaternion.identity);
            }
            else
            {
                if (quickSlot.isChangedSlot)
                {
                    Destroy(itemSpawner);
                    quickSlot.isChangedSlot = false;
                }
            }

            Vector3 placementPosition = Vector3.zero;


            placementPosition = new Vector3(
                hit.point.x,
                hit.point.y + itemSpawner.transform.position.y / 2,
                hit.point.z
                );

            itemSpawner.transform.position = placementPosition;

            // 충돌한 표면의 법선 방향을 고려하여 오브젝트를 회전시킴
            Quaternion placementRotation = Quaternion.FromToRotation(Vector3.up, hit.normal);

            CollisionCheck colCheck = itemSpawner.GetComponent<CollisionCheck>();
            if (Input.GetMouseButtonDown(0))
            {
                if (!colCheck.isOverlap)
                {
                    quickSlot.UseItem();
                    GameObject obj = Instantiate(curSlotItem, placementPosition, Quaternion.identity);
                    CollisionCheck objColCheck = obj.GetComponent<CollisionCheck>();
                    objColCheck.isPlaced = true;
                    objColCheck.SetOriginMaterial();
                }
                else
                {
                    Debug.Log("Don't place object!");
                }

            }
        }
        else
        {
            if (itemSpawner != null)
                Destroy(itemSpawner);
        }
    }

    private void ShopDetection()
    {
        // OverlapSphere를 통해 주변에 있는 플레이어 체크
        Collider[] colliders = Physics.OverlapSphere(transform.position, shopDetectionRange);

        foreach (Collider col in colliders)
        {
            if (col.tag.Equals(colTag[0]))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Shop shop = col.GetComponent<Shop>();
                    shop.Open();
                }
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
