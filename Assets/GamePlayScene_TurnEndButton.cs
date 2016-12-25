using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GamePlayScene_TurnEndButton :MonoBehaviour
{
	private bool ended=false;


	void OnMouseDown()
	{
		if(GameObject.Find("GameCenter").GetComponent<GamePlayScene_GameCenterScript>().ifsuspend)
			return;
	if(ended)return;	GameObject.Find("GameCenter").GetComponent<GamePlayScene_GameCenterScript>().TurnChange();
		StartCoroutine(ButtonInside());
	//Ȼ����ʱ��ʼ�ȴ��Է��Ĳ����ˣ�
	GameObject.Find("GameCenter").GetComponent<GamePlayScene_GameCenterScript>().EnemyTurn();

	}

//ʹ��ť����1��
	private IEnumerator ButtonInside()
	{
		ended=true;
		transform.Translate(0,0,-35);
		yield return new WaitForSeconds(3f);
		transform.Translate(0,0,35);
		ended=false;
	}
}