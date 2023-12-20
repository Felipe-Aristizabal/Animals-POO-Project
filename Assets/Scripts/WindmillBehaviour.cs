public class WindmillBehaviour : ObjectBehaviour
{
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
