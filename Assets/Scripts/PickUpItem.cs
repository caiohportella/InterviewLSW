using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float pickupDistance = 1.5f;
    [SerializeField] float ttl = 10f;

    Transform player;

    public Item item;
    public int count = 1;

    private void Awake()
    {
        player = GameManager.gm.player.transform;
    }

    private void Update()
    {
        ttl -= Time.deltaTime;
        if (ttl < 0) Destroy(gameObject);

        //when player gets close to item, attract it and destroy
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance > pickupDistance) return;
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        if (distance < 0.1f)
        {
            if(GameManager.gm.inventoryContainer != null)
            {
                GameManager.gm.inventoryContainer.Add(item, count);
            } else
            {
                Debug.LogWarning("No inventory found attatched to GM");
            }

            Destroy(gameObject);
        }
    }
}
