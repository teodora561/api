namespace KbstAPI.Core.Props
{
    public class PropertyConfig
    {
        public bool Visible { get; set; }
        public bool Editable { get; set; }

        public PropertyConfig(bool visible, bool editable)
        {
            Visible = visible;
            Editable = editable;
        }
    }
}
