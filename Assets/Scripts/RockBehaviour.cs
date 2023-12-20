public class RockBehaviour : ObjectBehaviour
{
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
