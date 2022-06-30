using AutoMapper;
using Business.Extensions;
using Core.DTOs;
using Core.Model;
using Core.Services;
using FluentValidation;
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
        private readonly IValidator<Order> _orderValidator;

        public OrdersController(IOrderService orderService, IBookService bookService, IMapper mapper, IValidator<Order> orderValidator)
        {
            _orderService = orderService;
            _bookService = bookService;
            _mapper = mapper;
            _orderValidator = orderValidator;
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
            var result = _orderValidator.Validate(_mapper.Map<Order>(dto));
            if (result.IsValid)
            {
                await OrderExtension.AddEx(_bookService, dto, _mapper);
                await _orderService.AddAsync(_mapper.Map<Order>(dto));
                return Ok();
            }
            return BadRequest();
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
            var result = _orderValidator.Validate(_mapper.Map<Order>(dto));
            if (result.IsValid)
            {
                var order = await OrderExtension.UpdateEx(_orderService, _bookService, dto, id);
                await _orderService.UpdateAsync(order);
                return Ok();
            }
            return BadRequest();
        }
    }
}