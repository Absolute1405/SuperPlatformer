using System.Collections;
using Platformer.Characters;
using UnityEngine;

public class trep : MonoBehaviour
{
    private bool redi = false;
    private Animator animator;
    [SerializeField]private Vector2 go_too;
    [SerializeField] private Vector2 go_too1;
    [SerializeField] private float second = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Health>(out var player))
        {
            player.TakeDamage(10);
        }
    }

    void Start()
    {

        StartCoroutine(Attack());
    }
    private IEnumerator Attack()
    {
        while (true)
        {
            if (redi)
            {
                transform.Translate(go_too );
                redi = false;
            }
            else
            {
                transform.Translate(go_too1 );
                redi = true;
            }

            for (float i = 0; i < second; i += Time.deltaTime)
            {
                yield return null;
            }
        }
    }
}
