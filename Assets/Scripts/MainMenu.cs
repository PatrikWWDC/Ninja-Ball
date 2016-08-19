using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour {

	private const float CAMERA_TRANSITION_SPEED = 3.0f;

	public GameObject levelButtonPrefab;
	public GameObject levelButtonContainer;

	public GameObject shopButtonPrefab;
	public GameObject shopButtonContainer;

	private Transform cameraTransform;
	private Transform cameraDesiredLookAt;

	public Material playerMaterial;

	public Text currencyText;

	private void Start() {
		changePlayerSkin (GameManager.Instance.currentSkinIndex);
		cameraTransform = Camera.main.transform;
		currencyText.text = GameManager.Instance.currency.ToString();

		Sprite[] thumbnails = Resources.LoadAll<Sprite>("Levels");
		foreach (Sprite thumbnail in thumbnails) {
			GameObject container = Instantiate (levelButtonPrefab) as GameObject;
			container.GetComponent<Image> ().sprite = thumbnail;
			container.transform.SetParent (levelButtonContainer.transform, false);

			string sceneName = thumbnail.name;
			container.GetComponent<Button> ().onClick.AddListener (() => loadLevel(sceneName));
		}

		Sprite[] textures = Resources.LoadAll<Sprite>("Player");
		int textureIndex = 0;
		foreach (Sprite texture in textures) {
			GameObject container = Instantiate (shopButtonPrefab) as GameObject;
			container.GetComponent<Image> ().sprite = texture;
			container.transform.SetParent (shopButtonContainer.transform, false);

			int index = textureIndex;
			container.GetComponent<Button> ().onClick.AddListener (() => changePlayerSkin(index));
			textureIndex++;
		}
	}

	private void Update() {
		if (cameraDesiredLookAt != null) {
			cameraTransform.rotation = Quaternion.Slerp (cameraTransform.rotation, cameraDesiredLookAt.rotation, CAMERA_TRANSITION_SPEED * Time.deltaTime);
		}
	}

	private void loadLevel(string sceneName) {
		SceneManager.LoadScene (sceneName);
	}

	public void lookAtMenu(Transform menuTransform) {
		cameraDesiredLookAt = menuTransform;
	}

	private void changePlayerSkin(int index) {

		float x = (index % 4) * 0.25f;
		float y = ((int)index / 4) * 0.25f;

		if (y == 0.0f) {
			y = 0.75f;
		} else if (y == 0.25f) {
			y = 0.5f;
		} else if (y == 0.5f) {
			y = 0.25f;
		} else if (y == 0.75f) {
			y = 0f;
		}

		GameManager.Instance.currentSkinIndex = index;
		GameManager.Instance.Save ();
		playerMaterial.SetTextureOffset("_MainTex", new Vector2(x, y));
	}
}