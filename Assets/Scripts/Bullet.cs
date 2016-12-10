using Assets.Scripts.Randoms;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float MinVal = 1f;
    public float Strength = 5f;
    public float SelfDestructionDist = 50f;

    private Vector3 _startPosition;
    private Vector3 _direction;

    public void Init(Vector3 direction, Vector3? position = null)
    {
        _direction = direction;
        SetStartPosition(position ?? transform.position);
    }

    public void SetStartPosition(Vector3 position)
    {
        _startPosition = position;
    }

    // Use this for initialization
    void Start()
    {
        SetStartPosition(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.white);

            var entity = contact.otherCollider.GetComponent<Entity>();
            Hit(entity);
        }

        // if needed place here OnDestroy method
        Destroy(this.gameObject);
    }

    private void Hit(Entity entity)
    {
        if(entity == null)
            return;

        entity.Hit(MinVal + BulletRandom.NextFloat);
    }
}
