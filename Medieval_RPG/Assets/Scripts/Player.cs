using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Mover
{
    [SerializeField] private AudioSource walkingSoundEffect;
    private bool isAlive = true;
    protected override void Start()
    {
        base.Start();
    }
    protected override void ReceiveDamage(Damage dmg)
    {
        if (!isAlive)
            return;
        base.ReceiveDamage(dmg);
        GameManager.instance.OnHitpointChange();
    }

    protected override void Death()
    {
        isAlive = false;
        GameManager.instance.deathMenuAnim.SetTrigger("Show");
    }
    private void FixedUpdate()
    {

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        if (isAlive)
        {
            UpdateMotor(new Vector3(x, y, 0));
            walkingSoundEffect.Play();
            if (walkingSoundEffect.isPlaying == false)
                walkingSoundEffect.Play();

        }
    }

    public void onLevelUp()
    {
        maxHitpoint++;
        hitPoint = maxHitpoint;
    }
    public void setLevel(int level)
    {
        for (int i = 0; i < level; i++)
        {
            onLevelUp();
        }
    }

    public void Heal(int healingAmount)
    {
        if (hitPoint == maxHitpoint)
            return;
        hitPoint += healingAmount;
        if (hitPoint > maxHitpoint)
            hitPoint = maxHitpoint;
        GameManager.instance.ShowText("+" + healingAmount.ToString() + "hp", 25, Color.green, transform.position, Vector3.up * 30, 1.0f);
        GameManager.instance.OnHitpointChange();
    }

    public void Respawn()
    {
        Heal(maxHitpoint);
        isAlive = true;
        immuneTime = Time.time;
        pushDirection = Vector3.zero;
        Debug.Log("Respawn");
    }

}
