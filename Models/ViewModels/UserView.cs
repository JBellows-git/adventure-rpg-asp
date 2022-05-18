using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureProject.Models.ViewModels
{
    public class UserView
    {
        public string Username { get; set; }
        public string Roles { get; set; }
        public string CharacterName { get; set; }

        public UserView()
        {
        }

        public UserView(string username, string roles, string characterName)
        {
            Username = username;
            Roles = roles;
            CharacterName = characterName;
        }
    }
}
