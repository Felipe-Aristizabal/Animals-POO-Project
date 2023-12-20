public class BonfireBehaviour : ObjectBehaviour
{
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
