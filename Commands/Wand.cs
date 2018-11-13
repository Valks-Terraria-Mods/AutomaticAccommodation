using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace AutomaticAccommodation.Commands
{
    public class Wand : ModCommand
    {
        int x1 = 0;
        int y1 = 0;
        int x2 = 0;
        int y2 = 0;

        public override CommandType Type {
            get { return CommandType.Chat; }
        }

        public override string Command {
            get { return "select";  }
        }

        public override string Usage {
            get { return "/select <point>";  }
        }

        public override string Description {
            get { return "Create a selection.";  }
        }

        public override void Action(CommandCaller caller, string input, string[] args)
        {
            Point tile = (caller.Player.Bottom + Vector2.UnitY).ToTileCoordinates();

            if (args.Length < 1) {
                caller.Reply("Specify some args.");
                return;
            }
            if (args[0].ToLower().Equals("1")) {
                
                x1 = tile.X;
                y1 = tile.Y;
            }
            if (args[0].ToLower().Equals("2")) {
                x2 = tile.X;
                y2 = tile.Y;
            }
            if (args[0].ToLower().Equals("copy")) {
                string message = "";
                for (int a = x1; a < x2; a++) {
                    for (int b = y1; b < y2; b++) {
                        message += Main.tile[a, b].type + " ";
                    }
                    message += "\n";
                }
                Main.NewText(message);
            }
        }
    }
}
