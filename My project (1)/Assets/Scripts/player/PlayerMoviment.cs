using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class PlayerMoviment : MonoBehaviour
{
    public Animator animator;
	public int playerLife = 100;
    int currentLife;
	public bool imortal;
	public float tempoIp;
	private Renderer mainRenderer;
	float axis;
	Vector2 velocidade;
	public bool ladoDireito = true;
    bool noChao = false;
	float chaoCheckRaio = 0.2f;
	public float jumpForce;
	public LayerMask deatTrigger;
	public Transform undergroundTrigger;

	public float MaxVelocidade = 7.5f;
    public Transform ChaoCheck;
	public LayerMask OnGround;
	bool playerDeathDown = false;
	public AudioSource jumpAudio;

	public Text lifeInTheScreen;

	[SerializeField] private GameObject hudRestartGame;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		currentLife = playerLife;
		mainRenderer = GetComponent<SpriteRenderer>();
	}

	void FixedUpdate()
	{

		lifeInTheScreen.text = "" + currentLife;
		
		// Verifica se o personagem está no chão.
       	noChao = Physics2D.OverlapCircle (ChaoCheck.position, chaoCheckRaio, OnGround);

		playerDeathDown = Physics2D.OverlapCircle(ChaoCheck.position, chaoCheckRaio, deatTrigger);

		axis = Input.GetAxis ("Horizontal");

		if(axis != 0){

			if (axis > 0 && !ladoDireito)
				Vire ();
			if (axis < 0 && ladoDireito)
				Vire ();

			animator.SetBool("run", true);

			velocidade = new Vector2 (axis * MaxVelocidade, GetComponent<Rigidbody2D>().velocity.y);

			GetComponent<Rigidbody2D>().velocity = velocidade;
		}else{
			animator.SetBool("run", false);
		}

		if(playerDeathDown){
			RestartScreen();
		}

		if(currentLife <= 0){
			PlayerDie();
		}


	}

	// Update is called once per frame
	void Update () {

        //Pulo do personagem.
        if (noChao && Input.GetButton ("Jump")) {
			jumpAudio.Play();
			animator.SetBool("jump", true);
			Invoke("EndJump", 0.6f);
			GetComponent<Rigidbody2D>().AddForce (new Vector2 (0, jumpForce), ForceMode2D.Impulse);
		}

        //Aumenta a velocidade do personagem.
        if(Input.GetKeyDown(KeyCode.LeftShift)){
            MaxVelocidade = 12.5F;
        }

        if(Input.GetKeyUp(KeyCode.LeftShift)){
            MaxVelocidade = 7.5f;
        }

	}

	void EndJump(){
		animator.SetBool("jump", false);
	}

	public void PlayerDamage(int damage){

        if(currentLife >= 0 && !imortal)
		{
			imortal = true;

			currentLife -= damage;

			StartCoroutine(PiscarDano());
			imortal = true;
			Invoke("ResetImortal", tempoIp);

		}else{
			PlayerDie();
		}

	}

	IEnumerator PiscarDano()
	{
		for(int i = 0; i < tempoIp; i++){
			mainRenderer.enabled = true;
			yield return new WaitForSeconds(0.1f);
      		mainRenderer.enabled = false;
      		yield return new WaitForSeconds(0.1f);
		}
		mainRenderer.enabled = true;
	}

	void ResetImortal()
	{
		imortal = false;
	}

	void PlayerDie()
	{
		animator.SetBool("die", true);
		Invoke("RestartScreen", 0.3f);
	}

	public void RestartScreen()
	{
		hudRestartGame.SetActive(true);
	}

	void Vire(){
		ladoDireito = !ladoDireito;

		Vector2 novoScale = new Vector2 (transform.localScale.x * -1, transform.localScale.y);

		transform.localScale = novoScale;
	}

	void OnDrawGizmosSelected() {
        if(ChaoCheck == null){
            return;
        }

        Gizmos.DrawWireSphere(ChaoCheck.position, chaoCheckRaio);
    }

}
