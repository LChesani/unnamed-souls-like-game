using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCasterController : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] GameObject spellHand;
    [SerializeField] GameObject spell;
    [SerializeField] Collider hearing;
    public MainCharacter player;
    [SerializeField] float speed;
    GameObject cast;
    float initialPos;
    float timer;
    System.Random rnd;
    void Start()
    {
        initialPos = transform.position.y - 0.5f;
        timer = 0.0f;
        player = GameObject.FindWithTag("Player").GetComponent<MainCharacter>();
        cast = new GameObject();
        cast = null;
        rnd = new System.Random();
    }
    Vector3 atkDir = Vector3.zero;
    void ataca()
    {
        if (cast != null) return;
        cast = Instantiate(spell, spellHand.transform.position, Quaternion.identity);
        cast.GetComponent<Spell>().target = player.transform.position;
    }

    // Update is called once per frame
    Vector3 playerDirection = Vector3.zero;
    void Update()
    {
        timer += 1.5f * Time.deltaTime;
        if(timer >= 2 * Mathf.PI) timer = 0.0f;
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
        {

            playerDirection = player.transform.position - transform.position;
            playerDirection *= (float)rnd.NextDouble();
            playerDirection.y = 0f;
            playerDirection = playerDirection.normalized * speed * Time.deltaTime;
            transform.Translate(playerDirection);
            ataca();
        }
        transform.position = new Vector3(transform.position.x, initialPos + 0.5f * Mathf.Cos(timer), transform.position.z);

        
    }
}
