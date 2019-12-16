namespace Supermarket
{
    interface ICheckout
    {
        void Scan(string item);
        int GetTotalPrice();
    }
}
