using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using TaskManagerAPI.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.WithOrigins(
                "http://localhost:3000",
                "http://localhost:5173",
                "https://harsha-050.github.io")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

builder.Services.AddSingleton<TaskStorage>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowFrontend");
app.UseAuthorization();
app.MapControllers();

app.Run();

public class TaskStorage
{
    private readonly List<TaskItem> _items = new();
    private int _nextId = 1;

    public List<TaskItem> GetAll() => _items;

    public TaskItem? GetById(int id) => _items.FirstOrDefault(t => t.Id == id);

    public TaskItem Add(string desc)
    {
        var task = new TaskItem
        {
            Id = _nextId++,
            Description = desc,
            IsCompleted = false
        };
        _items.Add(task);
        return task;
    }

    public bool Update(int id, string desc, bool done)
    {
        var task = GetById(id);
        if (task == null) return false;

        task.Description = desc;
        task.IsCompleted = done;
        return true;
    }

    public bool Delete(int id)
    {
        var task = GetById(id);
        if (task == null) return false;

        _items.Remove(task);
        return true;
    }
}

