using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Pellet : MonoBehaviour
{
    public KeepScore PlayerScore;
    public int points = 10;

    void Start()
    {
        PlayerScore = GameObject.Find("gakpo").GetComponent<KeepScore>();
    }

    protected virtual void Eat()
    {
        FindObjectOfType<GameManager>().PelletEaten(this);
    }

    private void GetEaten()
    {
        PlayerScore.Score += points;
        Destroy(gameObject, 0.1f); 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("pacman"))
        {
            GetEaten();
        }
    }

}