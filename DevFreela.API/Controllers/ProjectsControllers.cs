﻿using DevFreela.API.Entities;
using DevFreela.API.Models;
using DevFreela.API.Persistence;
using DevFreela.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace DevFreela.API.Controllers;

[ApiController]
[Route("api/projects")]
public class ProjectsControllers : ControllerBase
{
    private readonly DevFreelaDbContext _context;

    public ProjectsControllers(DevFreelaDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Get(string search = "")
    {
        //Acessa os dados relacionados utilizando o Include
        var projects = _context.Projects
            .Include(p => p.Client)
            .Include(p => p.Freelancer)
            .Where(p => !p.IsDeleted && (search == "" ||))
            .ToList();

        var model = projects.Select(ProjectViewModel.FromEntity).ToList();

        return Ok(model);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var project = _context.Projects
            .Include(p => p.Freelancer)
            .Include(p => p.Client)
            .Include(p => p.Comments)
            .SingleOrDefault(p => p.Id == id);

        var model = ProjectViewModel.FromEntity(project);

        return Ok(model);
    }

    [HttpPost]
    public IActionResult Post(CreateProjectInputModel model, int id)
    {
        var project = model.ToEntity();

        _context.Projects.Add(project);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetById), new { id = 1 }, model);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, UpdateProjectInputModel model)
    {
        var project = _context.Projects
            .SingleOrDefault(p => p.Id == id);

        if (project is null)
        {
            return NotFound();
        }

        //Utiliza para persistir os dados
        project.Update(model.Title, model.Description, model.TotalCost);

        _context.Projects.Update(project);
        _context.SaveChanges();

        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var project = _context.Projects
            .SingleOrDefault(p => p.Id == id);

        if (project is null)
        {
            return NotFound();
        }

        project.SetAsDeleted();
        _context.Projects.Update(project);
        _context.SaveChanges();

        return Ok();
    }

    [HttpPut("{id}/start")]
    public IActionResult Start(int id)
    {
        var project = _context.Projects.SingleOrDefault(p => p.Id == id);

        if (project is null)
        {
            return NotFound();
        }

        project.Start();

        _context.Projects.Update(project);
        _context.SaveChanges();

        return Ok();
    }

    [HttpPut("{id}/complete")]
    public IActionResult Complete(int id)
    {
        var project = _context.Projects.SingleOrDefault(p => p.Id == id);

        if (project is null)
        {
            return NotFound();
        }

        project.Complete();
        _context.Projects.Update(project);
        _context.SaveChanges();

        return Ok();
    }

    [HttpPost("{id}/comments")]
    public IActionResult PostComments(int id, CreateProjectCommentInputModel model)
    {
        var project = _context.Projects.SingleOrDefault(p => p.Id == id);

        if (project is null)
        {
            return NotFound();
        }

        var comment = new ProjectComment(model.Content, model.IdProject, model.IdUser);
        _context.ProjectComments.Add(comment);
        _context.SaveChanges();

        return Ok();
    }
}