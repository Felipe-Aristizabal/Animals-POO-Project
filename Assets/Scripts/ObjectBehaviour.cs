using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider))]
public class ObjectBehaviour : MonoBehaviour
{
    public Text textElement;
    
    public virtual void OnMouseDown()
    {
        textElement.text = "You click a: ";
    }
}
