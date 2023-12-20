// INHERITANCE - This class inherits from ObjectBehaviour
public class WindmillBehaviour : ObjectBehaviour
{
    // POLYMORPHISM - Overriding the OnMouseDown method from the base class
    public override void OnMouseDown()
    {
        base.OnMouseDown();
        textElement.text = "You click a: Windmill Tower";
        int score = GetActualScore();
        AddPoints(score + 3);
        SetActualScore();
        addClick("Windmill");
    }
}
