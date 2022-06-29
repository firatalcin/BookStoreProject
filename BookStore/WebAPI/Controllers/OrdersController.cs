using AutoMapper;
using Business.Extensions;
using Core.DTOs;
using Core.Model;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        public OrdersController(IOrderService orderService, IBookService bookService, IMapper mapper)
        {
            _orderService = orderService;
            _bookService = bookService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var order = await _orderService.GetAllAsync();
            var orderDto = _mapper.Map<List<OrderListDto>>(order);
            return Ok(orderDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await _orderService.GetByIdAsync(id);
            var orderDto = _mapper.Map<OrderListDto>(order);
            return Ok(orderDto);
        }

        [HttpPost]
        public async Task<IActionResult> Save(OrderAddDto dto)
        {
            await OrderExtension.AddEx(_bookService, dto, _mapper);
            await _orderService.AddAsync(_mapper.Map<Order>(dto));
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var order = await OrderExtension.DeleteEx(_orderService, _bookService, id);
            await _orderService.RemoveAsync(order);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(OrderUpdateDto dto, int id)
        {
            var order = await OrderExtension.UpdateEx(_orderService, _bookService, dto, id);
            await _orderService.UpdateAsync(order);
            return Ok();
        }
    }
}