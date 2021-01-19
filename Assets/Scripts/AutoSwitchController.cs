using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * A script that adds the following functionality:
 *   - If a game object enters the "trigger" of the switch then the
 *     the switch is automatically turned on. When you leave the "trigger"
 *     box the switch is automatically turned off.
 */

public class AutoSwitchController : MonoBehaviour
{
    // switchOff reflects whether the switch is on ot off
    private bool switchOff = true;

    // switchAnimator will hold the gameobjects Animator
    private Animator switchAnimator;

    // The Awake function of each class is called before the Start function. It is
    // here you should initialise class properties/variables like those above.
    void Awake()
    {
        // Get the Animator off the game object this script is attached to as
        // we'll need it later
        switchAnimator = gameObject.GetComponent<Animator>();

        // Let's turn off the switch to start with
        turnOff();
    }

    public void turnOn()
    {
        switchOff = false;
        switchAnimator.SetBool("SwitchOff", switchOff);
    }

    public void turnOff()
    {
        switchOff = true;
        switchAnimator.SetBool("SwitchOff", switchOff);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Someone entered the switch trigger");

        this.turnOn();
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Someone left the switch trigger");

        this.turnOff();
    }
}

