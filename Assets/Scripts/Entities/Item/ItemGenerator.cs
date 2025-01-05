using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entities.Item
{
    public class ItemGenerator : MonoBehaviour
    {
        [Header("Spawn settings")]
        [SerializeField] private List<GameObject> itemPrefabList;
        [SerializeField] private float spawnChance;
        [Header("Raycast setup")]
        [SerializeField] private float distanceBetweenObjects;
        [SerializeField] private float heightCheck;
        [SerializeField] private float rangeCheck;
        [SerializeField] private float generateHeight;
        [SerializeField] private LayerMask layerMask;
        [SerializeField] private Vector2 positivePosition;
        [SerializeField] private Vector2 negativePosition;

        private void Start()
        {
            //Debug.Log(itemPrefabList);
            SpawnItems();
        }

        public void SpawnItems()
        {
            for (float x = negativePosition.x; x < positivePosition.x; x += distanceBetweenObjects)
            {
                for (float z = negativePosition.y; z < positivePosition.y; z += distanceBetweenObjects)
                {
                    RaycastHit hit;
                    
                    GameObject itemPrefab = itemPrefabList[Random.Range(0, itemPrefabList.Count)];
                    
                    if (Physics.Raycast(new Vector3(x, heightCheck, z), Vector3.down, out hit, rangeCheck, layerMask))
                    {
                        if (spawnChance > Random.Range(0f, 101f))
                        {
                            // original
                            // Instantiate(itemPrefab, hit.point, Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0)), transform);
                            // v1 spawn directly
                            // Quaternion normalRotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
                            // Quaternion randomRotation = Quaternion.AngleAxis(Random.Range(0f, 360f), hit.normal); // need optimize
                            // Quaternion finalRotation = normalRotation * randomRotation;
                            // Instantiate(itemPrefab, hit.point, finalRotation, transform);
                            // v2 drop
                            GameObject item = Instantiate(itemPrefab, hit.point + Vector3.up * 0.5f, Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0)), transform);

                            // ensure item has Rigidbody
                            Rigidbody rb = item.GetComponent<Rigidbody>();
                            if (rb == null)
                            {
                                rb = item.AddComponent<Rigidbody>();
                            }
                            rb.mass = 1f;
                            rb.useGravity = true;
                            rb.isKinematic = false;
                            rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
                        }
                    }
                }
            }
        }

        public void DestroyItems()
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
        }
    }
}