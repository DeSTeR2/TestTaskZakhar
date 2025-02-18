using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInfoHolder : MonoBehaviour {
    [Header("Save headers")]
    [SerializeField] string _canonSprite;
    [SerializeField] string _ballSprite;
    [SerializeField] string _platformSprite;

    static public Dictionary<string, Sprite> Canon = new Dictionary<string, Sprite>();
    static public Dictionary<string, Sprite> Ball = new Dictionary<string, Sprite>();
    static public Dictionary<string, Sprite> Platform = new Dictionary<string, Sprite>();

    public static ShopInfoHolder instance;
    static bool onDestory = false;

    private void Awake() {
        if (onDestory == true) return;
        DontDestroyOnLoad(this.gameObject);

        int number = 1;
        while (true) {
            var sprite = Resources.Load<Sprite>($"Sprites/GameObjects/cannon_{number}");
            if (sprite == null) break;
            Canon.Add(sprite.name, sprite);
            number++;
        }

        number = 1;
        while (true) {
            var sprite = Resources.Load<Sprite>($"Sprites/GameObjects/b_{number}");
            if (sprite == null) break;
            Ball.Add(sprite.name, sprite);
            number++;
        }

        number = 1;
        while (true) {
            var sprite = Resources.Load<Sprite>($"Sprites/GameObjects/platform_{number}");
            if (sprite == null) break;
            Platform.Add(sprite.name, sprite);
            number++;
        }

        instance = this;
        onDestory = true;
    }

    public Sprite GetCanonImage() {
        string name = PlayerPrefs.GetString(_canonSprite, "cannon_1");
        if (Canon.ContainsKey(name)) 
            return Canon[name];
        return null;
    }

    public Sprite GetBallImage() {
        string name = PlayerPrefs.GetString(_ballSprite, "b_1");
        if (Ball.ContainsKey(name))
            return Ball[name];
        return null;
    }

    public Sprite GetPlatformImage() {
        string name = PlayerPrefs.GetString(_platformSprite, "platform_1");
        if (Platform.ContainsKey(name))
            return Platform[name];
        return null;
    }
}
