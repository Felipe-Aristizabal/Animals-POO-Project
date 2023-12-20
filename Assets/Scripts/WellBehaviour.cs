public class WellBehaviour : ObjectBehaviour
{
    public override void OnMouseDown()
    {
        base.OnMouseDown();
        textElement.text = "You click a: Well";
        int score = GetActualScore();
        AddPoints(score + 2);
        SetActualScore();
        addClick("Well");
    }
}
