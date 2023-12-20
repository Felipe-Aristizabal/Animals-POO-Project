// INHERITANCE - This class inherits from ObjectBehaviour
public class BonfireBehaviour : ObjectBehaviour
{
    // POLYMORPHISM - Overriding the OnMouseDown method from the base class
    public override void OnMouseDown()
    {
        base.OnMouseDown();
        textElement.text = "You click a: Bonfire";
        int score = GetActualScore();
        AddPoints(score + 4);
        SetActualScore();
        addClick("Bonfire");
    }
}
