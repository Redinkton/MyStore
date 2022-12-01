namespace MyStore.Core.Models
{
    public enum OrderStatus
    {
        registered,
        received,
        deliveredToCourier = 3,
        deliveredToPostamat = 4,
        deliveredToRecipient = 5,
        cancelled = 6,
    }
}
