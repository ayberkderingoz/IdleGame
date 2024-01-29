using System;
using UnityEngine;
using UnityEngine.UI;

namespace Common.UI
{
    [ExecuteInEditMode]
    public class ScaleEnforcer : MonoBehaviour
    {
        [NonSerialized]public bool IsSet;
        [NonSerialized]public float CanvasScale;
        [NonSerialized]public bool MathchingWidth;
        public bool overrideEditorValue = true;
        private RectTransform _rect;
        private CanvasScaler _canvasScaler;
        public float CanvasScaleInverse => 1 / CanvasScale;


        private void Awake()
        {
            _canvasScaler = GetComponent<CanvasScaler>();
            _rect = GetComponent<RectTransform>();
        }

        private void Update()
        {
            if (!overrideEditorValue) return;
            var screenRatio = (float)Screen.width / Screen.height;
            // if rect width is greater than height
            // if (_rect.rect.width > _rect.rect.height)
            if (screenRatio > 0.54f)
            {
                // set the scale to the height
                _canvasScaler.matchWidthOrHeight = 1;
                MathchingWidth = false;
            }
            else
            {
                _canvasScaler.matchWidthOrHeight = 0;
                MathchingWidth = true;
            }
            IsSet = true;
            CanvasScale = _rect.localScale.x;

        }
    }
}