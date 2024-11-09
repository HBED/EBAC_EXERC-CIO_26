using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Screens
{
    public enum ScreenType
    {
        Panel,
        Info_Panel,
        Shop
    }

    public class ScreenBase1 : MonoBehaviour
    {
        public ScreenType screenType;

        public List<Transform> listOfObjects;
        public List<Typper> listOfPhrases;

        public Image uiBackground;
        public bool startHided = false;

        [Header("Animation")]
        public float animationDuration = 0.3f;
        public float delayBetweenObjects = 0.5f;

        // Start is called before the first frame update
        private void Start()
        {
            if (startHided)
            {
                HideObjects();
            }
        }

        public virtual void Show()
        {
            ShowObjects();
            //Debug.Log("Show");
            //Debug.Log(screenType);
        }

        public virtual void Hide()
        {
            HideObjects();
            //Debug.Log("Hide");
            //Debug.Log(screenType);
        }

        private void HideObjects()
        {
            listOfObjects.ForEach(i => i.gameObject.SetActive(false));
            uiBackground.enabled = false;
        }

        private void ShowObjects()
        {
            for (int i = 0; i < listOfObjects.Count; i++)
            {
                var obj = listOfObjects[i];

                obj.gameObject.SetActive(true);
                obj.DOScale(0, animationDuration).From().SetDelay(i * delayBetweenObjects);
            }

            Invoke(nameof(ListStartType), delayBetweenObjects * listOfObjects.Count);
            uiBackground.enabled = true;
        }

        private void ListStartType()
        {
            for (int i = 0; i < listOfPhrases.Count; i++)
            {
                listOfPhrases[i].StartType();
            }
        }

        private void ForceShowObjects()
        {
            listOfObjects.ForEach(i => i.gameObject.SetActive(true));
            uiBackground.enabled = true;
        }
    }
}