using UnityEngine;
using UnityEngine.UI;
using TMPro;
using ShoppingCart;

namespace UI
{
    [RequireComponent(typeof(Button))]
    [RequireComponent(typeof(Image))]
    public class DropButton : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private Cart _shoppingCart;

        private Button _button;
        private Image _image;

        private void OnEnable()
        {
            _button.onClick.AddListener(OnButtonClick);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnButtonClick);
        }

        private void Awake()
        {
            _button = GetComponent<Button>();
            _image = GetComponent<Image>();
        }

        public void SetStatus(bool value)
        {
            _text.enabled = value;
            _image.enabled = value;
            _button.interactable = value;
        }

        private void OnButtonClick()
        {
            _shoppingCart.ThrowItem();
            SetStatus(false);
        }
    }
}