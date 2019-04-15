using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionManager : MonoBehaviour
{

    public Dropdown dropdown;
    private Speed movementSpeed;

    public void SetSpeed()
    {

        float speed;
        int index = dropdown.value;

        // set the speed base on the option, 5 for beginner and 10 for extreme 
        if (index == 2)
        {
            speed = 10.0f;
        }
        else
        {
            speed = 5.0f;
        }

        Speed.speed = speed;
    }
}