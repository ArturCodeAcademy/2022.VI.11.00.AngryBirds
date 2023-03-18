using UnityEngine;

[RequireComponent(typeof(Health))]
public class DestroyPigOnEndHealth : MonoBehaviour
{
    [SerializeField] private ParticleSystem _destroyEffect;

    void Start()
    {
        GetComponent<Health>().OnHealthEnd.AddListener(OnEndHealth);
    }

    void OnEndHealth()
    {
        Destroy(gameObject);
        Destroy(Instantiate(_destroyEffect.gameObject, transform.position,
            Quaternion.identity), _destroyEffect.main.duration);
    }
}
