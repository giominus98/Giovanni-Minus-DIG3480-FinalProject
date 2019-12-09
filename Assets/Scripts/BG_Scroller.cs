using System.Collections;
using UnityEngine;

public class BG_Scroller : MonoBehaviour
{
    public float scrollSpeed;
    public float tileSizeZ;
    public bool celebrationBG;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
        celebrationBG = false;
    }

    void Update()
    {
        float newPosition = Mathf.Repeat (Time.time * scrollSpeed, tileSizeZ);
        transform.position = startPosition + Vector3.forward * newPosition;

        if (celebrationBG == true)
        {
            scrollSpeed = -10;
        }
    }
}
