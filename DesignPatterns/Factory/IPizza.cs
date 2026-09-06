namespace DesignPatterns.Factory;

internal interface IPizza
{
    void Prepare();
    void Bake();
    void Cut();
    void Box();
    string GetDescription();
}
