using _Game_.Scripts.Court.Area.Enums;

namespace _Game_.Scripts.Court.Area.Interface
{
    public interface IArea
    {
        public CourtAreasTypes CourtAreaType { get; }

        void HighlightActivate();
        void HighlightInactivate();
    }
}