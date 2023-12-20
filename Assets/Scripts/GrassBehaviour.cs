// INHERITANCE - This class inherits from ObjectBehaviour
public class GrassBehaviour : ObjectBehaviour
{
    // POLYMORPHISM - Overriding the OnMouseDown method from the base class
    public override void OnMouseDown()
    {
        base.OnMouseDown();
        textElement.text = "You click a: Grass";
        int score = GetActualScore();
        AddPoints(score + 1);
        SetActualScore();
        addClick("Grass");
    }
}
