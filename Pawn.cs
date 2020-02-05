namespace umpggk_biernat_hosumbek
{
    class Pawn
    {
        public PawnType Type { get; private set; }
        public string Color { get; private set; }

        public Pawn(PawnType type, string color)
        {
            Type = type;
            Color = color;
        }
    }

    enum PawnType
    {
        pawn,
        king
    }
}
