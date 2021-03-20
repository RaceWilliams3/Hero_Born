using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotateSpeed = 150f;
    public float jumpVelocity = 10f;
    public float distanceToGround = 0.1f;
    public LayerMask groundLayer;

    public AudioSource reload;
    private GameBehavior _gameManager;

    public GameObject bullet;
    public float bulletSpeed = 100f;
    public int ammo;

    private float vInput;
    private float hInput;
    private CapsuleCollider _col;
    private Rigidbody _rb;
    //setup input flags
    private bool space = false;
    private bool shoot = false;

    

    bool IsGrounded()
    {
        Vector3 capsuleBottom = new Vector3(_col.bounds.center.x, _col.bounds.min.y, _col.bounds.center.z);
        bool grounded = Physics.CheckCapsule(_col.bounds.center, capsuleBottom, distanceToGround, groundLayer, QueryTriggerInteraction.Ignore);

        return grounded;
    }

    // Start is called before the first frame update
    void PlayShoot()
    {
        GetComponent<AudioSource>().Play(0);
    }

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _col = GetComponent<CapsuleCollider>();
        ammo = 20;

        _gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Enemy")
        {
            _gameManager.HP -= 5;
        }
        if (collision.gameObject.name == "Object004")
        {
            reload.Play();
            Debug.Log("Play sound");
        }

    }

    // Update is called once per frame
    void Update()
    {
        vInput = Input.GetAxis("Vertical") * moveSpeed;
        hInput = Input.GetAxis("Horizontal") * moveSpeed;
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            space = true;
        }
        if (Input.GetMouseButtonDown(0))
        {
            shoot = true;
        }

        if (_gameManager.needToFreeze == false)
        {
            float mouseInput = Input.GetAxis("Mouse X");
            Vector3 lookhere = new Vector3(0, mouseInput, 0);
            transform.Rotate(lookhere);
        }


    }
    void FixedUpdate()
    {
        if (space)
        {
            _rb.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
            space = false;
        }
            Vector3 rotation = Vector3.up * hInput;
            Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);

        _rb.MovePosition(this.transform.position + (this.transform.forward * vInput * Time.fixedDeltaTime)
            +(this.transform.right * hInput * Time.fixedDeltaTime));

        if (shoot && ammo > 0) 
        {
            GameObject newBullet = Instantiate(bullet, this.transform.position + this.transform.forward, this.transform.rotation) as GameObject;
            Rigidbody bulletRB = newBullet.GetComponent<Rigidbody>();
            bulletRB.velocity = this.transform.forward * bulletSpeed;
            PlayShoot();
            shoot = false;
            ammo += -1;
        }

    }
}
