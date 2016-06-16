using UnityEngine;
using System.Collections;

public class ReplaySystem : MonoBehaviour
{
    private const int bufferFrames = 1500;
    private MyKeyFrame[] keyFrames = new MyKeyFrame[bufferFrames];

    public bool isRecording = false;
    private int endFrame;
    private int currentFrame;

    private Rigidbody rigidBody;
    private GameManager gameManager;

    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
        currentFrame = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.recording)
        {
            Record();
        }
        else
        {
            PlayBack();
        }
        currentFrame++;
        currentFrame = currentFrame % bufferFrames;
        //Debug.Log("Current Frame " + currentFrame);
    }

    private void PlayBack()
    {
        if(isRecording)
        {
            endFrame = currentFrame;
            isRecording = false;
        }
        rigidBody.isKinematic = true;
        int frame = (currentFrame % endFrame);
        transform.position = keyFrames[frame].position;
        transform.rotation = keyFrames[frame].rotation;
    }
    private void Record()
    {
        if(!isRecording)
        {
            isRecording = true;
            currentFrame = 0;
        }
        rigidBody.isKinematic = false;
        keyFrames[currentFrame] = new MyKeyFrame(Time.time, transform.position, transform.rotation);
    }
}

public struct MyKeyFrame
{
    public float frameTime;
    public Vector3 position;
    public Quaternion rotation;

    public MyKeyFrame(float time, Vector3 pos, Quaternion rot)
    {
        frameTime = time;
        position = pos;
        rotation = rot;
    }
}
