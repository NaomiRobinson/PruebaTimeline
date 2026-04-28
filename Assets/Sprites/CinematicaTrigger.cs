using UnityEngine;
using UnityEngine.Playables;

public class ControladorCinematica : MonoBehaviour
{
    public PlayableDirector timeline;
    private bool yaSeActivo = false;

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player") && !yaSeActivo)
        {
            timeline.Play();
            yaSeActivo = true;
        }
    }
}