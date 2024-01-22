using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystemPersistent : MonoBehaviour
{
    public static EventSystemPersistent instance;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);
        }
    }
}
