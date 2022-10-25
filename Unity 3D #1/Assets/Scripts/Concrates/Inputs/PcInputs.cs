using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PcInputs
{
    public bool foceButtonDown => Input.GetKey(KeyCode.W);
    public float leftRight => Input.GetAxis("Horizontal");
}
