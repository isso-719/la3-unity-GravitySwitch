using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public string playStatus = "Start";
    public GameObject startText;
    public GameObject returnToStartText;
    public ParticleSystem playerParticle;
    public ParticleSystem explodeParticle;

    public ScoreController scoreController;

    public GameObject scoreText;
    public GameObject highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        playerParticle.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (playStatus == "Playing")
        {
            transform.position += new Vector3(0.07f, 0, 0);

            if (Input.GetMouseButtonDown(0))
            {
                Physics.gravity *= -1;
            }
        }
        else if (playStatus == "Start")
        {
            if (Input.GetMouseButtonDown(0))
            {
                playStatus = "Playing";
                GetComponent<Rigidbody>().useGravity = true;
                startText.SetActive(false);

                Physics.gravity = Vector3.down * 9.8f;

                playerParticle.Play();
            }
        }
        else if (playStatus == "GameOver")
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("Main");
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            playStatus = "GameOver";

            returnToStartText.SetActive(true);

            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<MeshRenderer>().enabled = false;

            playerParticle.Stop();
            explodeParticle.Play();

            scoreText.SetActive(true);
            highScoreText.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Item")
        {
            scoreController.AddScore();
            Destroy(other.gameObject);
        }
    }
}
