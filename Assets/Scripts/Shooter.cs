using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private float _fireSpeed;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _firePoint;

    public void Shoot(float direction)
    {
        GameObject curBullet = Instantiate(_bullet, _firePoint.position, Quaternion.identity);
        Rigidbody2D curBulletVelocity = curBullet.GetComponent<Rigidbody2D>();
        if (transform.localScale.x == 1)
            curBulletVelocity.velocity = new Vector2(_fireSpeed * 1, curBulletVelocity.velocity.y);
        else
            curBulletVelocity.velocity = new Vector2(_fireSpeed * -1, curBulletVelocity.velocity.y);
    }
}
