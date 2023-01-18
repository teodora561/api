namespace KbstAPI.Core.DTO
{
    public class ChangeResponseOneEntity<T>
    {
        public string[] Actions { get; set; }

        public T Entity { get; set; }


        public ChangeResponseOneEntity(string[] actions, T entity)
        {
            Actions = actions;
            Entity = entity;
        }
    }
}
