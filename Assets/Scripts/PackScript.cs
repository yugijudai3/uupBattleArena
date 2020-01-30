using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PackScript : MonoBehaviour
{
    public GameObject Pack;
    private GameObject Clone;
    public float speed;
    public float time;
    public float pastTime;
    public float interval;
    public bool waitFlag;
    public bool gameavailable;
    public AudioClip startSound;
    public AudioClip EndSound;
    public AudioClip ResultSound;
    public AudioClip ResultEndSound;
    AudioSource audioSource;

    void Start()
    {
        Invoke("StartSounds", 1);
        Invoke("GameStart", 3);
        Invoke("GameEnd", 33);
    }

    void Update()
    {
        audioSource = GetComponent<AudioSource>();
        time = Mathf.Floor(Time.time);

        if (time - pastTime == interval && waitFlag == false && time != 0)
        {
            if (gameavailable)
            {
                Clone = Instantiate(Pack, new Vector3(0, 0.15f, 0), Quaternion.identity);
                Clone.transform.Rotate(new Vector3(0, 90 * Mathf.Floor(Random.Range(2, 5) - 1) + Random.Range(-20, 20), 0));
                // Clone.transform.Rotate(new Vector3(0, Random.Range(160, 200), 0));
                // Clone.transform.Rotate(new Vector3(0, Random.Range(360, -360), 0));
                // Clone.gameObject.tag = "nanndemoiiyo" + Random.Range(1, 2).ToString();
                Rigidbody rb = Clone.GetComponent<Rigidbody>();
                rb.AddForce(Clone.transform.forward * speed, ForceMode.Impulse);
                pastTime = time;
                waitFlag = true;
            }
        } else if (waitFlag == true) {
            interval = Mathf.Floor(Random.Range(2, 4) - 1);
            waitFlag = false;
        }

        if (!gameavailable)
        {
            waitFlag = true;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "goal")
        {
            Destroy(this);
        } 
    }

    void GameStart()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();

        speed = 5;
        gameavailable = true;
        interval = Mathf.Floor(Random.Range(2, 4) - 1);

        Clone = Instantiate(Pack, new Vector3(0, 0.15f, 0), Quaternion.identity);
        Clone.transform.Rotate(new Vector3(0, 90 * Mathf.Floor(Random.Range(2, 5) - 1) + Random.Range(-20, 20), 0));
        // Clone.transform.Rotate(new Vector3(0, Random.Range(160, 200), 0));
        // Clone.transform.Rotate(new Vector3(0, Random.Range(360, -360), 0));
        Rigidbody rb = Clone.GetComponent<Rigidbody>();
        rb.AddForce(Clone.transform.forward * speed, ForceMode.Impulse);
        pastTime = time;
        waitFlag = true;
    }

    void GameEnd()
    {
        gameavailable = false;
        audioSource = GetComponent<AudioSource>();
        audioSource.Pause();
        audioSource.PlayOneShot(EndSound);
        GameObject[] AvailablePack = GameObject.FindGameObjectsWithTag("Pack");
        foreach(GameObject Pack in AvailablePack)
        {
            Rigidbody rb = Pack.GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
        }
        Invoke("EndSounds", 2);
    }

    void StartSounds()
    {
        audioSource.PlayOneShot(startSound);
    }

    void EndSounds()
    {
        Invoke("GoResult", 3);
        audioSource.PlayOneShot(ResultSound);
        audioSource.PlayOneShot(ResultEndSound);
    }

    void GoResult()
    {
        SceneManager.LoadScene("resultscene");
    }
}
