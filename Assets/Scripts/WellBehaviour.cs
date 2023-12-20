using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WellBehaviour : ObjectBehaviour
{
    public override void OnMouseDown()
    {
        base.OnMouseDown();
        textElement.text = "You click a: Well";
    }

    [SerializeField] private int score; 
}
