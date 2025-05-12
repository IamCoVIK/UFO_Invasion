using UnityEngine.XR.Interaction.Toolkit.Utilities;
using UnityEngine;

public class PortalSpawner : MonoBehaviour
{
    [SerializeField] private GameObject portalPrefab;
    private GameObject portal;

    [SerializeField] private Camera cameraToFace;
    [SerializeField] private GameObject CoachText;
    [SerializeField] private Animator blasterAnim;
    [SerializeField] private GameObject Hitmark;
    [SerializeField] private Blaster blaster;

    public bool TrySpawnPortal(Vector3 spawnPoint, Vector3 spawnNormal)
    {
        if (portal == null)
        {
            portal = Instantiate(portalPrefab);
            portal.name = portalPrefab.name;
            portal.transform.parent = transform;

            portal.transform.position = spawnPoint;

            portal.transform.rotation = Quaternion.FromToRotation(portal.transform.forward, spawnNormal);
            if (portal.transform.rotation.eulerAngles == new Vector3(0f, 180f, 180f))
            {
                portal.transform.rotation = Quaternion.Euler(new Vector3(0f, 180f, 0f));
            }

            CoachText.SetActive(false);
            blasterAnim.SetBool("Up", true);
            Hitmark.SetActive(true);
            blaster.charged = true;

            foreach (Transform i in GameObject.Find("Trackables").GetComponentsInChildren<Transform>())
            {
                i.gameObject.layer = 3;
            }

            return true;
        }
        else
            return false;
    }

    private void Update()
    {
        if (portal != null)
        {
            foreach (Transform i in GameObject.Find("Trackables").GetComponentsInChildren<Transform>())
            {
                if (i.gameObject.layer != 3)
                {
                    i.gameObject.layer = 3;
                }
            }
        }
    }
}

