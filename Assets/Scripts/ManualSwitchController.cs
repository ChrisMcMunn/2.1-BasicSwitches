using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * The script demonstrates a simple switch.
 * - The TriggerEnter/Exit functions "enable" the switch. When the switch
 *   is enabled and you press the spacebar then the switch is toggled (i.e.
 *   turned off if it was on OR turned on if it was off). 
 * - If the switch is not enabled i.e. you are not standing beside it, then
 *   pressing the spacebar has no effect.
 *   
 * - The script also demonstrates how to use triggers generally to enable/disable
 *   a game item, in this case a switch
 */

public class ManualSwitchController : MonoBehaviour
{
    // switchOff reflects whether the switch is on ot off
    private bool switchOff = true;

    // determines whether the switch is enabled or not. If enabled the
    // player can toggle the switch by pressing the spacebar
    private bool switchEnabled = false;

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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            toggleSwitch();
        }
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

    public void enableSwitch()
    {
        switchEnabled = true;
    }

    public void disableSwitch()
    {
        switchEnabled = false;
    }

    // The following function will toggle the switch but only if the 
    // switch is enabled
    public void toggleSwitch()
    {
        if (switchEnabled == true)
        {
            switchOff = !switchOff;
            switchAnimator.SetBool("SwitchOff", switchOff);
        }
        else
        {
            Debug.Log("Can't toggle switch as it's not enabled");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Someone entered the switch trigger");

        this.enableSwitch();
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Someone left the switch trigger");

        this.disableSwitch();
    }

}
