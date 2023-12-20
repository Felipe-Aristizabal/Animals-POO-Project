public class GrassBehaviour : ObjectBehaviour
{
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
