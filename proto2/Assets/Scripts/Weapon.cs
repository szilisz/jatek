using UnityEngine;
using TMPro;


public class Weapon : MonoBehaviour
{
    public float damage = 20f;
    public float range = 100f;
    public float fireRate = 2f;
    private float nextTimeToFire = 2f;

    public Camera fpsCam;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI finalScore;
    public static int score = 0;
    public PlayerMovement player;
    public GameObject impactEffect;
    public AudioClip impactSound;




void Update()
    {
        if(Input.GetMouseButtonDown(0) && Time.time >= nextTimeToFire && PauseMenu.isPaused == false)
        {

            nextTimeToFire = Time.time + 1f / fireRate;
            Invoke("Shoot", 0.3f);
            player.animator.SetTrigger("attack");
        }

    }

    void Shoot()
    {
        SoundManager.instance.PlaySound(impactSound);
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range));
        {
            if (hit.transform != null)
            {
                Target target = hit.transform.GetComponent<Target>();

                if (target != null)
                {

                    target.TakeDamage(damage);
                    score++;
                    scoreText.SetText("Score: " + score);
                    finalScore.SetText("Your final score is " + score);
                }

                GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGO, 0.8f);
            }
        }
    }
}
