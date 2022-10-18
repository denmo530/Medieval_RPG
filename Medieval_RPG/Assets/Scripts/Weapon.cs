using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collidable
{

    [SerializeField] private AudioSource swordSoundEffect;

    // Damage struct
    public int[] damagePoint = { 1, 2, 4, 5, 6, 8 };
    public float[] pushForce = { 2.0f, 2.2f, 2.4f, 3.0f, 3.3f, 4.0f };

    // Upgrade
    public int weaponLevel = 0;
    public SpriteRenderer spriteRenderer;

    // Swing
    private Animator anim;
    private float coolDown = 0.5f;
    private float lastSwing;
    protected override void Start()
    {
        base.Start();
        anim = GetComponent<Animator>();
    }

    protected override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time - lastSwing > coolDown)
            {
                lastSwing = Time.time;
                Swing();
            }
        }
    }

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.tag == "Fighter")
        {
            if (coll.name == "Player")
                return;

            // create a new damage object, then we will send it to the fighter we hit
            Damage dmg = new Damage
            {
                damageAmount = damagePoint[weaponLevel],
                origin = transform.position,
                pushForce = pushForce[weaponLevel]
            };
            coll.SendMessage("ReceiveDamage", dmg);

            //Debug.Log(coll.name);
        }

    }

    private void Swing()
    {
        anim.SetTrigger("Swing");
        swordSoundEffect.Play();

    }

    public void UpgradeWeapon()
    {
        weaponLevel++;
        spriteRenderer.sprite = GameManager.instance.weaponSprites[weaponLevel];

    }

    public void SetWeaponLevel(int level)
    {
        weaponLevel = level;
        spriteRenderer.sprite = GameManager.instance.weaponSprites[weaponLevel];
    }
}
