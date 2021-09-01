using UnityEngine;

public class DestroyOnTimer : MonoBehaviour
{
    public float timeToDestruction;

    private float currentTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime > timeToDestruction)
        {
            Destroy(gameObject);
        }

        currentTime += Time.deltaTime;
    }
}
