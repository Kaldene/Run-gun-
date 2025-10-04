using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(BoxCollider2D))]

public class PlayerCore : MonoBehaviour
{
    public static PlayerCore Instance {get; private set;}
    [HideInInspector] public Rigidbody2D rb;
    
    [HideInInspector] public BoxCollider2D boxCollider;
    
    [HideInInspector] public Animator animator;
        
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
}
