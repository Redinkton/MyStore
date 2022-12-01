using MyStore.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using MyStore.WebApi.Controllers;
using MyStore.WebApi.DTOs;
using MyStore.Infrastructure.Repositories.Interfaces;

namespace MyStore.Controllers;


[ApiController]
[Route("orders")]
public class OrdersController : BaseController
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public OrdersController(IOrderRepository orderRepository,IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetById(int id)
    {
        var order = await _orderRepository.GetById(id);

        if (order == null)
        {
            return NotFound();
        }

        var orderDto = _mapper.Map<ResultOrderDto>(order);

        return Ok(orderDto);
    }

    [HttpPost]
    public async Task<ActionResult> Create(CreateOrderDto orderDto)
    {
        if (orderDto == null)
            return BadRequest();

        //проверка количества товаров
        if (orderDto.OrderList.List.Length > 10)
            return BadRequest("The request failed");

        var order = _mapper.Map<Order>(orderDto);

        await _orderRepository.Create(order);

        //если 0, то запрещено создавать на закрытый постамат
        if (order.OrderId == 0)
            return BadRequest("Forbidden");

        return CreatedAtAction(nameof(GetById), new { id = order.OrderId }, order);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, UpdateOrderDto orderDto)
    {
        if (id != orderDto.Id)
            return BadRequest("Order ID mismatch");

        var order = await _orderRepository.GetById(id);

        if (order == null)
        {
            return NotFound($"Order with Id = {id} not found");
        }

        await _orderRepository.Update(_mapper.Map<Order>(orderDto));

        return Ok(orderDto);
    }


    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        var orderToDelete = await _orderRepository.GetById(id);

        if (orderToDelete == null)
        {
            return NotFound($"Order with Id = {id} not found");
        }

        await _orderRepository.Delete(orderToDelete);

        return Ok($"Order with Id = {id} deleted");
    }
}