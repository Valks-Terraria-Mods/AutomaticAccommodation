using AutomaticAccommodation.UI;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;

namespace AutomaticAccommodation
{
	class AutomaticAccommodation : Mod
	{
        internal HouseUI houseUI;
        internal UserInterface userInterface;

        public AutomaticAccommodation()
		{
            
		}

        public override void Load()
        {
            houseUI = new HouseUI();
            houseUI.Activate();
            userInterface = new UserInterface();
            userInterface.SetState(houseUI);
        }

        public override void UpdateUI(GameTime gameTime)
        {
            if (userInterface != null && HouseUI.visible)
                userInterface.Update(gameTime);
        }

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int MouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
            if (MouseTextIndex != -1)
            {
                layers.Insert(MouseTextIndex, new LegacyGameInterfaceLayer(
                    "ExampleMod: Coins Per Minute",
                    delegate
                    {
                        if (HouseUI.visible)
                        {
                            userInterface.Draw(Main.spriteBatch, new GameTime());
                        }
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
            }
        }
    }
}
