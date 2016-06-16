using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;


public class CameraController : MonoBehaviour
{
    public GameObject target;
    public float panSpeed = 50.0f;
    public bool simpleVerticalRotate = true;

    private Vector3 offsetFromTarget;

    void Start()
    {
        offsetFromTarget =  transform.position - target.transform.position;
    }

    
    void Update()
    {
        float rH = CrossPlatformInputManager.GetAxis("R_Horizontal");
        float rV = CrossPlatformInputManager.GetAxis("R_Vertical");
        if (rH > 0 || rH < 0)
        {
            offsetFromTarget = Quaternion.AngleAxis(Time.deltaTime * panSpeed * rH, Vector3.up) * offsetFromTarget;
        }
        if (rV > 0 || rV < 0)
        {
            if(!simpleVerticalRotate)
            {
                //This method goes directly up and down but causes camera jitter when looking directly 
                //up or down at the target, this happens due to the camera up flipping sides
                //Vector3 projectedOffsetOnGround = Vector3.ProjectOnPlane(offsetFromTarget, Vector3.up); //flaten offset to ground
                //Vector3 rotatedForwardVector = Quaternion.AngleAxis(90.0f, Vector3.up) * projectedOffsetOnGround.normalized; //rotate to get perpendicular vector
                offsetFromTarget = Quaternion.AngleAxis(Time.deltaTime * panSpeed * rV, transform.right) * offsetFromTarget;
                //uncomment to see projected and perpendicular vectors
                //Debug.DrawRay(target.transform.position, projectedOffsetOnGround, Color.blue);
                //Debug.DrawRay(target.transform.position, rotatedForwardVector, Color.cyan);
            }
            else
            {
                offsetFromTarget = Quaternion.AngleAxis(Time.deltaTime * panSpeed * rV, Vector3.forward) * offsetFromTarget;
            }
        }
        transform.position = target.transform.position + offsetFromTarget;
        transform.LookAt(target.transform);
    }
    
    //private void LateUpdate()
    //{
    //    float horizChange = CrossPlatformInputManager.GetAxis("R_Horizontal");
    //    float vertChange = CrossPlatformInputManager.GetAxis("R_Vertical");

    //    transform.position = target.transform.position + offsetFromTarget;

    //    //rotate along the Z-axis by amount vertChange, centered around the point the player is at
    //    transform.RotateAround(target.transform.position, Vector3.forward, vertChange);
    //    //rotate along the Y-axis by amount horizChange, centered around the point the player is at
    //    transform.RotateAround(target.transform.position, Vector3.up, horizChange);
    //    offsetFromTarget = transform.position - target.transform.position;
    //    transform.LookAt(target.transform);
    //}
}
