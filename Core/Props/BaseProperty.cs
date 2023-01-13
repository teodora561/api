namespace KbstAPI.Core.Props
{
    public abstract class BaseProperty
    {
        public abstract string Name { get; protected set; }
        
        public abstract PropertyType Type { get; protected set; }

        protected BaseProperty() 
        {

        }
    }
}
