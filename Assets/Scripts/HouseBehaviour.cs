public class HouseBehaviour : ObjectBehaviour
{
    public override void OnMouseDown()
    {
        base.OnMouseDown();
        textElement.text = "You click a: House";
        int score = GetActualScore();
        AddPoints(score + 1);
        SetActualScore();
        addClick("House");
    }
}
