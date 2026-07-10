namespace Order.Domain.Enums;

/// <summary>
/// وضعیت‌های ممکن برای سفارش
/// </summary>
public enum OrderStatus
    {
        Pending = 1,        // در انتظار تایید
        Confirmed = 2,      // تایید شده
        Processing = 3,     // در حال پردازش
        Shipped = 4,        // ارسال شده
        Delivered = 5,      // تحویل داده شده
        Cancelled = 6,      // لغو شده
        Rejected = 7        // رد شده
    }
