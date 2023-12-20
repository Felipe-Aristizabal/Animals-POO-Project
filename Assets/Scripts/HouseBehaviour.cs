// INHERITANCE - This class inherits from ObjectBehaviour
public class HouseBehaviour : ObjectBehaviour
{
    // POLYMORPHISM - Overriding the OnMouseDown method from the base class
    public override void OnMouseDown()
    {
        base.OnMouseDown();
        textElement.text = "You click a: House";
        int score = GetActualScore();
        AddPoints(score + 1);
        SetActualScore();
        addClick("House");
    }
}
