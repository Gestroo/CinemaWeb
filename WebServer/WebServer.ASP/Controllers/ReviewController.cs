﻿using CinemaLibrary.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using WebServer.ASP.Models;
using WebServer.ASP.Repositories;

namespace WebServer.ASP.Controllers;
[ApiController]
[Route("reviews")]
[Authorize]
public class ReviewController : ControllerBase
{
    private readonly IReviewRepository _reviewRepository;
    private readonly IClientRepository _clientRepository;

    public ReviewController(IReviewRepository reviewRepository,IClientRepository clientRepository)
    {
        _reviewRepository = reviewRepository;
        _clientRepository = clientRepository;
    }
    private Client? GetClientInRequest()
    {
        var id = HttpContext.User.FindFirst("user");
        return id is null ? null : _clientRepository.GetClientById(Convert.ToInt32(id.Value));
    }
    [HttpGet]
    public IActionResult GetReviews()
    {
        var client = GetClientInRequest();
        if (client is null) return BadRequest("token is incorrect");
        return Ok(_reviewRepository.GetReviews(client).Select(g=>new ReviewModel(g)));
    }
    //TODO: Filter or Ne Filter
    [HttpPost]
    public IActionResult AddReview(ReviewModel model)
    {
        var client = GetClientInRequest();
        if (client is null) return BadRequest("token is incorrect");
        try
        {
            return Ok(new ReviewModel(_reviewRepository.AddReview(model, client)));
        }
        catch (Exception e )
        {
            return BadRequest(e.Message);
        }
    }
}