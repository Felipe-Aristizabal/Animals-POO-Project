public class BarnBehaviour : ObjectBehaviour
{
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
