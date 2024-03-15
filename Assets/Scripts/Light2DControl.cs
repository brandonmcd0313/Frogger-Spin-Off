using System.Collections;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Rendering.Universal; // Use the correct namespace for Light2D

public class Light2DControl : MonoBehaviour
{
    //kill the script so project can build i guess
    /*
    [SerializeField]
    private bool activateOnStart = true; // Determines whether to activate the light on start
    //WHY THE HECK IS THIS NOT WORKING
    //IMPORT IS CORRECT
    private Light2D light2D; // Variable to hold the reference to Light2D component

    void Start()
    {
        // Cache the Light2D component at start
        light2D = GetComponentInChildren<Light2D>(); // If the Light2D is not on the same GameObject, use GetComponentInChildren<Light2D>()

        // If activateOnStart is true, turn the light on then off after a delay
        if (activateOnStart && light2D != null)
        {
            StartCoroutine(ControlLight());
        }
        else if (light2D == null)
        {
            Debug.LogError("Light2D component not found on the GameObject or its children.");
        }
    }

    // Public method to start the light control coroutine
    public void StartLightControl()
    {
        if (light2D != null)
        {
            StartCoroutine(ControlLight());
        }
        else
        {
            Debug.LogWarning("Light2D component not found!");
        }
    }

    private IEnumerator ControlLight()
    {
        // Turn on the light
        light2D.enabled = true;

        // Wait for 3 seconds
        yield return new WaitForSeconds(3);

        // Turn off the light
        light2D.enabled = false;
    }
    */
}
/*
 
                             .-----.
                            /7  .  (
                           /   .-.  \
                          /   /   \  \
                         / `  )   (   )
                        / `   )   ).  \
                      .'  _.   \_/  . |
     .--.           .' _.' )`.        |
    (    `---...._.'   `---.'_)    ..  \
     \            `----....___    `. \  |
      `.           _ ----- _   `._  )/  |
        `.       /"  \   /"  \`.  `._   |
          `.    ((O)` ) ((O)` ) `.   `._\
            `-- '`---'   `---' )  `.    `-.
               /                  ` \      `-.
             .'                      `.       `.
            /                     `  ` `.       `-.
     .--.   \ ===._____.======. `    `   `. .___.--`     .''''.
    ' .` `-. `.                )`. `   ` ` \          .' . '  8)
   (8  .  ` `-.`.               ( .  ` `  .`\      .'  '    ' /
    \  `. `    `-.               ) ` .   ` ` \  .'   ' .  '  /
     \ ` `.  ` . \`.    .--.     |  ` ) `   .``/   '  // .  /
      `.  ``. .   \ \   .-- `.  (  ` /_   ` . / ' .  '/   .'
        `. ` \  `  \ \  '-.   `-'  .'  `-.  `   .  .'/  .'
          \ `.`.  ` \ \    ) /`._.`       `.  ` .  .'  /
    LGB    |  `.`. . \ \  (.'               `.   .'  .'
        __/  .. \ \ ` ) \                     \.' .. \__
 .-._.-'     '"  ) .-'   `.                   (  '"     `-._.--.
(_________.-====' / .' /\_)`--..__________..-- `====-. _________)
                 (.'(.'
 */