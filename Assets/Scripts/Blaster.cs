using UnityEngine;
using UnityEngine.EventSystems;


public class Blaster : MonoBehaviour
{
    [SerializeField] private Game game;
    private BlasterActions inputActions;
    [SerializeField] private Animator animator;
    [SerializeField] private ParticleSystem particles;
    [SerializeField] private ParticleSystem particles2;
    [SerializeField] private AudioSource audioSource;

    public bool charged;

    void Awake()
    {
        inputActions = new BlasterActions();
        inputActions.Gameplay.Blast.performed += ctx => Blast();
        inputActions.Gameplay.Enable();
        charged = false;
    }

    void OnDestroy()
    {
        inputActions.Gameplay.Disable();
    }

    void Blast()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (charged)
        {
            animator.SetTrigger("Shoot");
            particles.Play();
            particles2.Play();
            audioSource.Stop();
            audioSource.Play();

            Ray ray;

            ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("UFO"))
                {
                    game.UpdateScore(hit.collider.gameObject.GetComponent<UFO>().Killed());
                }
                else
                {

                }
            }
            else
            {

            }
        }
    }
}
