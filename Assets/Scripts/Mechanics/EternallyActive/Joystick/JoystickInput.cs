using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class JoystickInput
{
    //Holds the variables for both the Joystick's direction (in x and y) and the Joystick's direction relative to the world (in x and z)

    public static Vector3 joystickDirection;
    public static Vector3 worldOrientedJoystickDirection;
}
