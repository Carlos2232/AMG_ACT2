using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    [SerializeField] private GameObject rocketPrefab;
    [SerializeField] private float fireInterval = 3f; 
    [SerializeField] private float rocketSpeed = 6f;
    [SerializeField] private int rocketCount = 4;
    [SerializeField] private float firstRocketOffset = 45f; 
    private float _barrageTimer;

    private void Update()
    {
        _barrageTimer += Time.deltaTime;

        if (_barrageTimer >= fireInterval)
        {
            _barrageTimer = 0f;
            FireRadialBurst();
        }
    }

    private void FireRadialBurst()
    {
        float spacingAngle = 360f / rocketCount;

        for (int i = 0; i < rocketCount; i++)
        {
            float currentAngle = firstRocketOffset + (i * spacingAngle);

            GameObject rocketObj = Instantiate(rocketPrefab, transform.position, Quaternion.identity);
            Rocket rocketScript = rocketObj.GetComponent<Rocket>();

            if (rocketScript != null)
            {
                rocketScript.Initialize(transform.position, currentAngle, rocketSpeed);
            }
        }
    }

    public void IncreaseRocketCount()
    {
        if (rocketCount < 8)
        {
            rocketCount++;
        }
    }
}