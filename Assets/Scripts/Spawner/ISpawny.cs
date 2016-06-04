public interface ISpawny
{
    Spawner parent {get;set;}
    int value { get; set; }
    int movementspeed { get; set; }
    void moveTo(float x, float y,float z);
    void fire();
}