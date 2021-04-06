namespace Endorblast.Lib.Game.Components
{
    interface IComponentOwner
    {

        
        T GetComponent<T>() where T : Component;
        void Remove(Component component);
        
        

    }
}