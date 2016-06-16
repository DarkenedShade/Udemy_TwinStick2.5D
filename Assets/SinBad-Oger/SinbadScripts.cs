using UnityEngine;
using System.Collections;

public class SinbadScripts : MonoBehaviour {

    public GameObject LeftSword;
    public GameObject RightSword;

    public Transform LeftHandle;
    public Transform RightHandle;

    public Transform LeftSheath;
    public Transform RightSheath;

    private SkinnedMeshRenderer l_sword;
    private SkinnedMeshRenderer r_sword;
    private Rigidbody rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        l_sword = LeftSword.GetComponent<SkinnedMeshRenderer>();
        r_sword = RightSword.GetComponent<SkinnedMeshRenderer>();

        //rigidBody.constraints = rigidBody.constraints | RigidbodyConstraints.FreezePositionX;
    }

	public void AttachSwordsToHandle()
    {
        l_sword.rootBone = LeftHandle;
        r_sword.rootBone = RightHandle;
    }

    public void AttachSwordsToSheath()
    {
        l_sword.rootBone = LeftSheath;
        r_sword.rootBone = RightSheath;
    }

}
