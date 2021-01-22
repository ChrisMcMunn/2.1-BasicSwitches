using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulbController : MonoBehaviour
{
    private Animator BulbAnimator;
    public bool bulbOn;

    void Awake()
    {
        BulbAnimator = gameObject.GetComponent<Animator>();
        turnOff();
    }

    public void turnOn()
    {
       
        BulbAnimator.SetBool("bulbState", true);
         bulbOn = true;
    }

    public void turnOff()
    {
        
        BulbAnimator.SetBool("bulbState", false);
        bulbOn = false;
    }
}
