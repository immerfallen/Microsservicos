using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{    public enum BoMenuType
    {
        mt_STRING = 1,
        mt_POPUP,
        mt_SEPERATOR
    }
    public class UserMenu
    {
        private string str_menu_description;
        private string parent_id;
        private string unique_id;
        private BoMenuType type;
        private int menu_position;
        private string _image;

        public string Image
        {
            get { return this._image; }
            set { this._image = value; }
        }

        public string Description
        {
            get { return this.str_menu_description; }
            set { this.str_menu_description = value; }
        }
        public string Parent
        {
            get { return this.parent_id; }
            set { this.parent_id = value; }
        }
        public string UniqueID
        {
            get { return this.unique_id; }
            set { this.unique_id = value; }
        }
        public BoMenuType Type
        {
            get { return this.type; }
            set { this.type = value; }
        }
        public int Position
        {
            get { return this.menu_position; }
            set { this.menu_position = value; }
        }

        public UserMenu(string Description, string Parent, string UniqueID, BoMenuType Type, int Position, string Image)
        {
            this.str_menu_description = Description;
            this.parent_id = Parent;
            this.unique_id = UniqueID;
            this.type = Type;
            this.menu_position = Position;
            this._image = "./" + Image;

        }
    }
}
