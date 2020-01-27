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
    public AudioClip startSound;
    public AudioClip EndSound;
    public AudioClip ResultSound;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        GetComponent<AudioSource>().Play();
        Invoke("GameStart", 5);
        Invoke("GameEnd", 15);
    }

    void Update()
    {

        
        time = Mathf.Floor(Time.time);
        if (time - pastTime == interval && waitFlag == false && time != 0)
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
        } else if (waitFlag == true) {
            interval = Mathf.Floor(Random.Range(2, 4) - 1);
            waitFlag = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "goal")
        {
            Destroy(this);
        } 
    }

    void GameStart()
    {
        speed = 5;
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
        
        SceneManager.LoadScene("resultscene");
    }
    void Startsunds()
    {
        audioSource.PlayOneShot(startSound);

    }
}
