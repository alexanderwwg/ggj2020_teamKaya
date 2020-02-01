using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head_AniScript : MonoBehaviour
{
    public Animator animator;
    public bool talking;
    // Start is called before the first frame update
    void Start()
    {
        SetIsTalking(talking);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetIsTalking(bool talk)
    {
        animator.SetBool("IsTalking",talk);
    }
}
