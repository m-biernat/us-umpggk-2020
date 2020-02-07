namespace umpggk_biernat_hosumbek
{
    class Field
    {
        public FieldType Type { get; private set; }
        public Pawn Pawn { get; set; }

        public Field(FieldType type = FieldType.neutral, Pawn pawn = null)
        {
            Type = type;
            Pawn = pawn;
        }

        public bool isEmpty()
        {
            if (Pawn == null)
                return true;
            else
                return false;
        }
    }

    enum FieldType
    {
        neutral,
        kingsValley
    }
}
