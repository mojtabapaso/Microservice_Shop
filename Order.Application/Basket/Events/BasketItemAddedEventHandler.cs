using MediatR;
using Order.Infrastructure.Persistence.Repositories;

namespace Order.Application.Basket.Events;

/// <summary>
/// هندلر مربوط به رویداد افزودن کالا به سبد خرید
/// </summary>
public class BasketItemAddedEventHandler(IBasketRepository basketRepository) : IRequestHandler<BasketItemAddedEvent>
{
    public async Task Handle( BasketItemAddedEvent request, CancellationToken cancellationToken)
    {
        // دریافت سبد خرید بر اساس شناسه
        var basket = await basketRepository.FindByIdAsync(request.basketId);
        basket?.MarkAsUpdated();
        
        // بروزرسانی زمان آخرین تغییر سبد خرید
        // این مقدار برای تشخیص سبدهای منقضی و مدیریت آن‌ها استفاده می‌شود.
    }
}