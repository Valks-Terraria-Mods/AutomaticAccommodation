using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;
using System;
using Terraria.ID;
using System.Linq;

namespace AutomaticAccommodation.UI
{
    public class HouseUI : UIState
    {
        public UIPanel housePanel;
        public static bool visible = false;

        public override void OnInitialize()
        {
            housePanel = new UIPanel();
            housePanel.SetPadding(0);
            housePanel.Left.Set(400f, 0f);
            housePanel.Top.Set(100f, 0f);
            housePanel.Width.Set(170f, 0f);
            housePanel.Height.Set(70f, 0f);
            housePanel.BackgroundColor = new Color(73, 94, 171);

            housePanel.OnMouseDown += new UIElement.MouseEvent(DragStart);
            housePanel.OnMouseUp += new UIElement.MouseEvent(DragEnd);

            Texture2D buttonDeleteTexture = ModLoader.GetTexture("Terraria/UI/ButtonDelete");
            UIImageButton closeButton = new UIImageButton(buttonDeleteTexture);
            closeButton.Left.Set(140, 0f);
            closeButton.Top.Set(10, 0f);
            closeButton.Width.Set(22, 0f);
            closeButton.Height.Set(22, 0f);
            closeButton.OnClick += new MouseEvent(CloseButtonClicked);
            housePanel.Append(closeButton);

            base.Append(housePanel);
        }

        private void CloseButtonClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            Main.PlaySound(SoundID.MenuOpen);
            visible = false;
        }

        Vector2 offset;
        public bool dragging = false;
        private void DragStart(UIMouseEvent evt, UIElement listeningElement)
        {
            offset = new Vector2(evt.MousePosition.X - housePanel.Left.Pixels, evt.MousePosition.Y - housePanel.Top.Pixels);
            dragging = true;
        }

        private void DragEnd(UIMouseEvent evt, UIElement listeningElement)
        {
            Vector2 end = evt.MousePosition;
            dragging = false;

            housePanel.Left.Set(end.X - offset.X, 0f);
            housePanel.Top.Set(end.Y - offset.Y, 0f);

            Recalculate();
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            Vector2 MousePosition = new Vector2((float)Main.mouseX, (float)Main.mouseY);
            if (housePanel.ContainsPoint(MousePosition))
            {
                Main.LocalPlayer.mouseInterface = true;
            }
            if (dragging)
            {
                housePanel.Left.Set(MousePosition.X - offset.X, 0f);
                housePanel.Top.Set(MousePosition.Y - offset.Y, 0f);
                Recalculate();
            }
        }
    }
}
