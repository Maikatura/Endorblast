namespace Endorblast.Lib.Game.Data
{
    public class CharacterInformation
    {
        private int accountID;
        private int characterID;
        private int roleID;

        
        
        private string characterName;
        private string roleTag;
        
        
        public int AccountId
        {
            get => accountID;
            set => accountID = value;
        }

        public int CharacterId
        {
            get => characterID;
            set => characterID = value;
        }

        public int RoleId
        {
            get => roleID;
            set => roleID = value;
        }

        public string CharacterName
        {
            get => characterName;
            set => characterName = value;
        }

        public string RoleTag
        {
            get => roleTag;
            set => roleTag = value;
        }
    }
}