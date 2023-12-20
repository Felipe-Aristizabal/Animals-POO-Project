// INHERITANCE - This class inherits from ObjectBehaviour
public class BarnBehaviour : ObjectBehaviour
{
    // POLYMORPHISM - Overriding the OnMouseDown method from the base class
    public override void OnMouseDown()
    {
        base.OnMouseDown();
        textElement.text = "You click a: Barn";
        int score = GetActualScore();
        AddPoints(score + 2);
        SetActualScore();
        addClick("Barn");
    }
}
