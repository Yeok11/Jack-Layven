using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    protected virtual void Tell() { }

    protected virtual void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && GameManager.isStory == false && GameManager.messageStop == false)
        {
            Tell();
        }
    }
}
