using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider))]
public class ObjectBehaviour : MonoBehaviour
{
    public Text textElement;
    public int actualScore;

    public static Dictionary<string, bool> clickedObjects = new Dictionary<string, bool>();

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

    public virtual void OnMouseDown()
    {
        textElement.text = "You click a: ";
    }

    public virtual void AddPoints(int point)
    {
        actualScore = point;
    }

    public virtual int GetActualScore()
    {
        actualScore = DataManagement.instance.GetScorePlayer();
        return actualScore;
    }

    public virtual void SetActualScore()
    {
        DataManagement.instance.SetScorePlayer(actualScore);
    }

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
