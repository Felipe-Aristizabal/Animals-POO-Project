// INHERITANCE - This class inherits from ObjectBehaviour
public class RockBehaviour : ObjectBehaviour
{
    // POLYMORPHISM - Overriding the OnMouseDown method from the base class
    public override void OnMouseDown()
    {
        base.OnMouseDown();
        textElement.text = "You click a: Rock";
        int score = GetActualScore();
        AddPoints(score + 2);
        SetActualScore();
        addClick("Rock");
    }
}
