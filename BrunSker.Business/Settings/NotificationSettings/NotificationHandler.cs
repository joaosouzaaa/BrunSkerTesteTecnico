using BrunSker.Business.Interfaces.Notification;

namespace BrunSker.Business.Settings.NotificationSettings
{
    public class NotificationHandler : INotificationHandler
    {
        private List<DomainNotification> _notificationList;

        public NotificationHandler()
        {
            _notificationList = new List<DomainNotification>();
        }

        public List<DomainNotification> GetAllNotifications() => _notificationList;

        public bool HasNotification() => _notificationList.Any();

        public bool AddDomainNotification(string key, string message)
        {
            var domainNotification = new DomainNotification
            {
                Key = key,
                Message = message
            };

            _notificationList.Add(domainNotification);
            
            if (_notificationList.Any())
                return false;

            return true;
        }
    }
}
