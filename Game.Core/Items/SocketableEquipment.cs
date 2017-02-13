using Game.Core.Gems;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Core.Items
{
    //current base class for all equipment pieces
    public class SocketableEquipment
    {
        public SocketConfiguration Sockets { get; set; }
    }

    public class SocketConfiguration
    {
        public List<SocketLinkSet> Links { get; set; } = new List<SocketLinkSet>();
        public int MaxLinks => Links.Max(x => x.Sockets.Count());

        public override string ToString()
        {
            return string.Join(" ", Links.Select(x => x.ToString()));
        }
    }

    public enum SocketColor
    {
        [Description("r")]
        Red,
        [Description("g")]
        Green,
        [Description("b")]
        Blue,
        [Description("w")]
        White
    }

    public class SocketLinkSet
    {
        public List<Socket> Sockets { get; set; } = new List<Socket>();

        public IEnumerable<Gem> ActiveGems => Sockets.Select(x => x.Gem).OfType<ActiveGem>();
        public IEnumerable<Gem> SupportGems => Sockets.Select(x => x.Gem).OfType<SupportGem>();

        public override string ToString()
        {
            return string.Join("", Sockets.Select(x => x.Color.GetDescription()));
        }
    }

    public class Socket
    {
        public Socket(SocketColor color)
        {
            Color = color;
        }
        public SocketColor Color { get; set; }
        public IGem Gem { get; set; }

        public override string ToString()
        {
            return Color.GetDescription();
        }
    }

    public class SocketParser
    {
        //examples:
        //RGB G G W yeilds link(RGB) + G + G + W

        public SocketConfiguration ParseSockets(string str)
        {
            return new SocketConfiguration
            {
                Links = str.ToLower().Split(' ').Select(x => GetLinks(x)).ToList()
            };
        }

        private SocketLinkSet GetLinks(string str)
        {
            return new SocketLinkSet
            {
                Sockets = str.Select(x => GetSocket(x)).ToList()
            };
        }

        public Socket GetSocket(char color)
        {
            if (color == 'r') return new Socket(SocketColor.Red);
            else if (color == 'g') return new Socket(SocketColor.Green);
            else if (color == 'b') return new Socket(SocketColor.Blue);
            else if (color == 'w') return new Socket(SocketColor.White);

            throw new ArgumentException($"{color} is not a valid socket color");
        }
    }
}
