public interface IDamageable
{
    int EnemyHealth { get; set; }
    //bool HasBeenHit { get; set; }
    void TakeDamage(int damageAmount);
}
