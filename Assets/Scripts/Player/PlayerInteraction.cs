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
            // 표면이 위를 향하는지 확인 (임계값을 0.7로 설정, 이는 임의로 설정한 값으로 필요에 따라 조정 가능)
            if (hit.normal.y > 0.7f)
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
                        itemSpawner = Instantiate(curSlotItem, Vector3.zero, Quaternion.identity);
                        quickSlot.isChangedSlot = false;
                    }
                }

                // 오브젝트의 바운딩 박스 크기를 고려하여 배치 위치 조정
                Bounds itemBounds = itemSpawner.GetComponent<Collider>().bounds;
                float objectHeight = itemBounds.size.y;

                Vector3 placementPosition = hit.point + new Vector3(0, objectHeight / 2, 0);

                itemSpawner.transform.position = placementPosition;

                // 충돌한 표면의 법선 방향을 고려하여 오브젝트를 회전시킴
                Quaternion placementRotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
                itemSpawner.transform.rotation = placementRotation;

                CollisionCheck colCheck = itemSpawner.GetComponent<CollisionCheck>();
                if (Input.GetMouseButtonDown(0))
                {
                    if (colCheck.isSafetyZone && !Shop.isUIActive)
                    {
                        quickSlot.UseItem();
                        GameObject obj = Instantiate(curSlotItem, placementPosition, placementRotation);
                        CollisionCheck objColCheck = obj.GetComponent<CollisionCheck>();
                        objColCheck.isPlaced = true;
                        objColCheck.SetOriginMaterial();
                    }
                    else
                    {
                        Debug.Log("해당 오브젝트를 설치할 수 없습니다!");
                    }
                }
            }
            else
            {
                Debug.Log("옆면에는 설치할 수 없습니다!");
                if (itemSpawner != null)
                {
                    Destroy(itemSpawner);
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
