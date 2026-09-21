using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private Transform playerTransform;
    [SerializeField] private float collectionRadius = 1.5f;

    private void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
    }

    private void Update()
    {
        if (playerTransform == null) return;

        float deltaX = playerTransform.position.x - transform.position.x;
        float deltaZ = playerTransform.position.z - transform.position.z;
        float distance = Mathf.Sqrt((deltaX * deltaX) + (deltaZ * deltaZ));

        if (distance <= collectionRadius)
        {
            RocketMovement barrage = playerTransform.GetComponent<RocketMovement>();
            if (barrage != null)
            {
                barrage.IncreaseRocketCount();
            }
            Destroy(gameObject);
        }
    }
}