using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider))]
public class ObjectBehaviour : MonoBehaviour
{
    // ENCAPSULATION - Public field for Text component
    public Text textElement; 
    // ENCAPSULATION - Public field for score
    public int actualScore; 

    // ABSTRACTION - Static dictionary to keep track of clicked objects
    public static Dictionary<string, bool> clickedObjects = new Dictionary<string, bool>();

    // ENCAPSULATION - Initialization of clickedObjects dictionary
    protected virtual void Awake()
    {
        clickedObjects["Animal"] = false;
        clickedObjects["Barn"] = false;
        clickedObjects["Bonfire"] = false;
        clickedObjects["Grass"] = false;
        clickedObjects["House"] = false;
        clickedObjects["Rock"] = false;
        clickedObjects["Sky"] = false;
        clickedObjects["Well"] = false;
        clickedObjects["Windmill"] = false;
    }

    // POLYMORPHISM - Virtual method for mouse click handling
    public virtual void OnMouseDown()
    {
        textElement.text = "You clicked a: ";                                   // Displays a message in the Text component
    }

    // ABSTRACTION - Abstract method for adding points
    public virtual void AddPoints(int point)
    {
        actualScore = point;
    }

    // ENCAPSULATION - Gets the player score
    public virtual int GetActualScore()
    {
        actualScore = DataManagement.instance.GetScorePlayer();
        return actualScore;
    }

    // ENCAPSULATION - Sets the player score
    public virtual void SetActualScore()
    {
        DataManagement.instance.SetScorePlayer(actualScore);
    }

    // ABSTRACTION - Abstract method for adding clicks
    protected void addClick(string objectName)
    {
        if (clickedObjects.ContainsKey(objectName) && !clickedObjects[objectName])
        {
            clickedObjects[objectName] = true;
        }
        else if (!clickedObjects.ContainsKey(objectName))
        {
            Debug.LogError("Clicked object not found in dictionary: " + objectName);
        }
    }
}
