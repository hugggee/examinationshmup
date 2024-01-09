using TMPro; // för texten
using UnityEngine;

public class PlayerMouseMovement : MonoBehaviour
{
    public TextMeshProUGUI HPText = null; 
    public TextMeshProUGUI PointText = null;
    public Playerdata CurrentPlayerData = null;
    public float moveSpeed = 2.5f; // farten
    public float stopDistance = 0.1f; // närheten till musen för att stoppa farten




    void Update()
    {
        HPText.text = CurrentPlayerData.HP + " HP";
        PointText.text = CurrentPlayerData.Points + " Points";
        // få muspositionen i skärmen
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; // så att z-koordinaten är 0

        // direktionen till musen
        Vector3 direction = (mousePosition - transform.position).normalized;

        // distansen till musen
        float distance = Vector3.Distance(transform.position, mousePosition);

        // om spelaren är nära musen
        if (distance > stopDistance)
        {
            // rör objekten till musen med farten
            transform.Translate(direction * moveSpeed * Time.deltaTime);
        }
        else
        {
            // gör så att playern sluta röra sig nära msuen
            transform.Translate(Vector3.zero);
        }

        // stäng av farten om musen är utanför spelet så den inte flyger iväg förevigt o fy fan vad jag hatade det som inåt helvete
        if (Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f)
        {
            moveSpeed = 2.5f; // om musen är tillbaka sätt farten till 5 igen
        }
    }
}
