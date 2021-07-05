namespace csharpcore
{
    public class Player
    {
        public string Name { get; }
        public int Place { get; set; }
        public int Purse { get;  set;}
        public bool IsInPenaltyBox { get; set;}

        private PlayerState state;
        
        public Player(string name)
        {
            Name = name;
            state = new PlayerInGameState(this);
        }

        public void IncrementPurse()
        {
            state.IncrementPurse();
        }

        public void Move(int roll)
        {
            state.Move(roll);
        }

        public void SetInInPenaltyBox()
        {
            state.SetInInPenaltyBox();
        }

        public void ReleaseFromPenaltyBox()
        {
            state.ReleaseFromPenaltyBox();
        }
    }
    
    
    public abstract class PlayerState
    {
        protected Player player;

        public PlayerState(Player player)
        {
            this.player = player;
        }
        
        public abstract PlayerState IncrementPurse();
        public abstract PlayerState Move(int roll);
        public abstract PlayerState SetInInPenaltyBox();
        public abstract PlayerState ReleaseFromPenaltyBox();
    }

    public class PlayerInGameState : PlayerState
    {
        public PlayerInGameState(Player player) : base(player) { }

        public override PlayerState IncrementPurse()
        {
            player.Purse = player.Purse + 1;
            return this;
        }

        public override PlayerState Move(int roll)
        {
            player.Place =  player.Place + roll;
            if (player.Place > 11) 
                player.Place =  player.Place - 12;
            
            return this;
        }

        public override PlayerState SetInInPenaltyBox()
        {
            player.IsInPenaltyBox  = true;
            
            return new PlayerInJailState(player);
        }

        public override PlayerState ReleaseFromPenaltyBox()
        {
            return this;
        }
    }

    public class PlayerInJailState : PlayerState
    {
        public PlayerInJailState(Player player) : base(player) { }

        public override PlayerState IncrementPurse()
        {
            return this;
        }

        public override PlayerState Move(int roll)
        {
            return this;
        }

        public override PlayerState SetInInPenaltyBox()
        {
            return this;
        }

        public override PlayerState ReleaseFromPenaltyBox()
        {
            player.IsInPenaltyBox = false;
            return new PlayerInGameState(player);
        }
    }
}