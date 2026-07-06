using Microservice.Contracts.Product.Protos;
using MediatR;
using Microservice.Core.ApiResult;
using Microservice.Core.Interfaces;
using Microservice.Core.Mediator;
using Order.Application.Basket.Events;
using Order.Infrastructure.Configurations;
using Order.Infrastructure.Repositories;
using static Microservice.Contracts.Product.Protos.ProductService;
using BasketEntity = Order.Domain.Entities.Basket;

namespace Order.Application.Basket.Commands;

/// <summary>
/// هندلر مربوط به افزودن یک کالا به سبد خرید
/// </summary>
public class AddItemToBasketCommandHandler(IBasketRepository basketRepository, IMediator mediator, IUnitOfWork unitOfWork,
    DbContextBasket dbContextBasket, ProductServiceClient productServiceClient)
    : ICommandHandler<AddItemToBasketCommand, ServiceResult>
{
    public async Task<ServiceResult> Handle(AddItemToBasketCommand request, CancellationToken cancellationToken)
    {
        //
        var reee = await productServiceClient.GetProductDataAsync(new GetProductDataRequestDto { ProductId = request.ProductId.ToString()}
        ,deadline:DateTime.UtcNow.AddSeconds(5), cancellationToken: cancellationToken);

        // دریافت سبد خرید فعال کاربر (به همراه آیتم‌های آن)
        var basket = await basketRepository.GetActiveBasketWithItemsByUserId(request.UserId);
        // اگر سبد خریدی وجود نداشت، یک سبد جدید ایجاد می‌کنیم.
        if (basket is null)
        {
            basket = new BasketEntity();
            basket = basket.CreateBasket(request.UserId);

            // افزودن اولین کالا به سبد
            basket.AddItem(request.ProductId, request.Quantity, request.UunitPrice);
            await dbContextBasket.AddAsync(basket);

            // ثبت سبد جدید در دیتابیس
            await basketRepository.AddAsync(basket);
        }
        else
        {
            // در صورت وجود سبد، کالا را به آن اضافه می‌کنیم.
            basket.AddItem(request.ProductId, request.Quantity, request.UunitPrice);

            // اعمال تغییرات روی سبد
            basketRepository.Update(basket);
        }

        // تغییرات را در دیتابیس ذخیره می‌کنیم.
        // چون شناسه سبد توسط دیتابیس تولید می‌شود، قبل از ارسال Eventها
        // باید تغییرات ذخیره شوند تا شناسه معتبر در اختیار داشته باشیم.
        int saveResult = await unitOfWork.SaveChangesAsync(cancellationToken);
        // دریافت شناسه سبد فعال کاربر
        long basketId = await basketRepository.GetActiveBasketIdByUserId(request.UserId);

        // ارسال Event برای انجام پردازش‌های پس از افزودن کالا
        await mediator.Send( new BasketItemAddedEvent(basketId), cancellationToken);

        // بروزرسانی کش سبد خرید
        await mediator.Send(new RestoreCacheBasketEvent(request.UserId), cancellationToken);

        // بازگرداندن نتیجه موفق عملیات
        return ServiceResult.Success();
    }
}