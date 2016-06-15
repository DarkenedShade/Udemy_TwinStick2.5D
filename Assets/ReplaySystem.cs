using UnityEngine;
using System.Collections;

public class ReplaySystem : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

public struct MyKeyFrame
{
    public float frameTime;
    private Vector3 position;
    private Quaternion rotation;

    public MyKeyFrame(float time, Vector3 pos, Quaternion rot)
    {
        frameTime = time;
        position = pos;
        rotation = rot;
    }
}
