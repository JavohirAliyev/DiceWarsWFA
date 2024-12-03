using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DiceWars.DAL.Entities;

namespace DiceWars.DAL
{
    partial class PlayerManager
    {
        public List<Player> Sort(ByAttribute attribute)
        {
            //sorting all players
            switch (attribute)
            {
                case ByAttribute.Name:
                    var players = GetAll();
                    players.Sort(new ByNameComparer());
                    return players;
                case ByAttribute.Champions:
                    //sorting players whose scores are higher than 0
                    return GetAll().Where(a => a.Score > 0).ToList();
                case ByAttribute.Losers:
                    //sorting players whose scores are equal to or lower than 0
                    return GetAll().Where(a => a.Score <= 0).ToList();
            }

            return null;
        }

        private class ByNameComparer : IComparer<Player>
        {
            //a function for sorting players by their names
            public int Compare(Player? x, Player? y)
            {
                return string.Compare(x.Name, y.Name);
            }
        }




        public List<Player> Search(ByAttribute attribute, string searchTerm)
        {
            switch (attribute)
            {
                case ByAttribute.Name:
                    //searching players with a particular searchterm taken from the search textbox
                    return GetAll().Where(a => a.Name.ToLower().Contains(searchTerm.ToLower())).ToList();
            }

            return null;
        }
    }
}
