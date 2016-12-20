using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GamePlayScene_TurnEndButton :MonoBehaviour
{
	private ended=false;


	void OnMouseDown()
	{
		if(GameObject.Find("GameCenter").GetComponent<GamePlayScene_GameCenterScript>().ifsuspend)
			return;
	if(ended)return;	GameObject.Find("GameCenter").GetComponent<GamePlayScene_GameCenterScript>().TurnChange();
		StartCoroutine(ButtonInside());
	}

//ʹ��ť����1��
	private IEnumerator ButtonInside()
	{
		ended=true;
		transform.Translate(0,0,-40);
		yield return new WaitForSeconds(1);
		transform.Translate(0,0,40);
		ended=false;
	}
}