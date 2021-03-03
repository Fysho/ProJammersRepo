﻿using HexCardGame.Localisation;

namespace HexCardGame.UI
{
    public class UiTextLocalized : UiText
    {
        public LocalizationIds Id;

        protected override void Awake()
        {
            base.Awake();
            var text = Localization.Instance.Get(Id);
            SetText(text);
        }
    }
}