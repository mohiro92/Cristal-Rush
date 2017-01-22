using System.Linq;
using Assets.Scripts.Randoms;
using Assets.Scripts.Mastermind;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float MinVal = 1f;
    public int Strength = 5;
    public float SelfDestructionDist = 50f;
    public float Speed = 1f;
    public GameObject ExplosionPrefab;

    private AudioSource shootAudio;
    private bool _isDestroyed = false;
    private Rigidbody rigidbody;
    private Vector3 rotation;

    void Start()
    {
        shootAudio = GetComponent<AudioSource>();
        if (shootAudio)
        {
            //shootAudio.Play();
        }
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(transform.forward * Speed);
        gameObject.SetActive(true);
        rotation = new Vector3(Random.Range(-360, 360), Random.Range(-360, 360), Random.Range(-360, 360));
    }

    private void Update()
    {
        transform.eulerAngles += 5 * Time.deltaTime * rotation;
    }

    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.white);
            
            Hit(contact.otherCollider);
        }

    }

    private readonly object _hitLock = new object();
    private void Hit(Collider collider)
    {
        var entity = collider.GetComponent<Entity>();
        lock (_hitLock)
        {
            if (_isDestroyed)
                return;

            SelfDestroy();
        }

        //if (entity != null) entity.Hit(MinVal + BulletRandom.NextFloat(Strength));

        var mastermindSymbol = collider.GetComponent<Crystal>();
        if (mastermindSymbol) mastermindSymbol.BulletHit(transform);

        var cipherChecker = collider.GetComponent<CipherCheck>();
        if (cipherChecker) cipherChecker.Check();

        GameObject explosionObject = Instantiate(ExplosionPrefab);
        explosionObject.transform.Translate(transform.position);
    }

    private void SelfDestroy()
    {
        _isDestroyed = true;
        // if needed place here OnDestroy method
        DestroyObject(gameObject);
    }
}
