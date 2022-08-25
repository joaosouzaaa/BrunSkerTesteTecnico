using BrunSker.Business.Settings.NotificationSettings;

namespace BrunSker.Business.Interfaces.Notification
{
    public interface INotificationHandler
    {
        List<DomainNotification> GetAllNotifications();
        bool HasNotification();
        bool AddDomainNotification(string key, string message);
    }
}
