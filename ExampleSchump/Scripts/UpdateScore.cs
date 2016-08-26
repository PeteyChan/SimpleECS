using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpdateScore : MonoBehaviour 
{
	Text _scoreLabel;
	int _score = 0;

	void Start()
	{
		_scoreLabel = GetComponent<Text>();
		CustomEvent.AddListener<UpdateScoreEvent>(OnUpdateScoreEvent);
	}

	void OnUpdateScoreEvent(UpdateScoreEvent args)
	{
		_score += args.points;
		_scoreLabel.text = _score.ToString();
	}

}

public class UpdateScoreEvent : IEvent
{
	public UpdateScoreEvent(int pointValue)
	{
		points = pointValue;
	}
	public int points;
}
