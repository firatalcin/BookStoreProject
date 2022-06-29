using AutoMapper;
using Core.DTOs;
using Core.Model;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Extensions
{
    public static class OrderExtension
    {
        public static async Task AddEx(IBookService _bookService, OrderAddDto dto, IMapper _mapper)
        {
            var book = await _bookService.GetByIdAsync(dto.BookId);
            dto.TotalPrice = book.Price * dto.Quantity;
            book.Stock -= dto.Quantity;
        }

        public static async Task<Order> DeleteEx(IOrderService _orderService, IBookService _bookService, int id)
        {
            var order = await _orderService.GetByIdAsync(id);
            var book = await _bookService.GetByIdAsync(order.BookId);
            book.Stock += order.Quantity;
            return order;
        }

        public static async Task<Order> UpdateEx(IOrderService _orderService, IBookService _bookService, OrderUpdateDto dto, int id)
        {
            var order = await _orderService.GetByIdAsync(id);
            var book = await _bookService.GetByIdAsync(order.BookId);
            var total1 = dto.Quantity - order.Quantity;
            var total2 = order.Quantity - dto.Quantity;

            if (dto.Quantity > order.Quantity)
            {
                book.Stock -= total1;
                order.TotalPrice += total1 * book.Price;
            }
            else if (dto.Quantity < order.Quantity)
            {
                book.Stock += total2;
                order.TotalPrice -= total2 * book.Price;
            }
            order.Quantity = dto.Quantity;
            return order;
        }
    }
}