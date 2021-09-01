using UnityEngine;
using UnityEngine.Events;

public class MonoEventsBehavior : MonoBehaviour
{
    public UnityEvent StartEvent;
    // Start is called before the first frame update
    void Start()
    {
        StartEvent.Invoke();
    }
}
