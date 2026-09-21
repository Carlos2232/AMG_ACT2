using UnityEngine;

public class Rocket : MonoBehaviour
{
    private float spawnX;
    private float spawnZ;
    private float fixedY;
    private float angleRadians;
    private float speed;
    private float timer;

    public void Initialize(Vector3 spawnPosition, float angleDegrees, float rocketSpeed)
    {
        spawnX = spawnPosition.x;
        spawnZ = spawnPosition.z;
        fixedY = spawnPosition.y;

        angleRadians = angleDegrees * Mathf.Deg2Rad;
        speed = rocketSpeed; 
        timer = 0f;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        float computedX = spawnX + (speed * Mathf.Cos(angleRadians) * timer);
        float computedZ = spawnZ + (speed * Mathf.Sin(angleRadians) * timer);

        transform.position = new Vector3(computedX, fixedY, computedZ);

        if (timer >= 5f)
        {
            Destroy(gameObject);
        }
    }
}