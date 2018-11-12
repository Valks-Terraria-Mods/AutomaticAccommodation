using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.UI;

namespace AutomaticAccommodation.UI
{
    public class HouseUI : UIState
    {
        public DragableUIPanel dragableUIPanel;
        public static bool visible = false;

        public override void OnInitialize()
        {
            dragableUIPanel = new DragableUIPanel();
            dragableUIPanel.SetPadding(0);

            dragableUIPanel.Left.Set(400f, 0f);
            dragableUIPanel.Top.Set(100f, 0f);
            dragableUIPanel.Width.Set(170f, 0f);
            dragableUIPanel.Height.Set(70f, 0f);
            dragableUIPanel.BackgroundColor = new Color(73, 94, 171);
        }

        private void CloseButtonClicked(UIMouseEvent evt, UIElement listeningElement)
        {
            Main.PlaySound(SoundID.MenuOpen);
            visible = false;
        }
    }
}
