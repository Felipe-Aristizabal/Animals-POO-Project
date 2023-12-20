public class SkyBehaviour : ObjectBehaviour
{
    public override void OnMouseDown()
    {
        base.OnMouseDown();
        textElement.text = "You click a: Sky";
        int score = GetActualScore();
        AddPoints(score + 1);
        SetActualScore();
        addClick("Sky");
    }
}
