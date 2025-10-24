using Microsoft.AspNetCore.Builder;using Microsoft.AspNetCore.Builder;

using Microsoft.Extensions.DependencyInjection;using Microsoft.Extensions.DependencyInjection;

using Microsoft.Extensions.Hosting;using Microsoft.Extensions.Hosting;

using System;using System;

using System.Collections.Generic;using System.Collections.Generic;

using System.Linq;using System.Linq;

using TaskManagerAPI.Models;using TaskManagerAPI.Models;



var builder = WebApplication.CreateBuilder(args);var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();builder.Services.AddSwaggerGen();



builder.Services.AddCors(options =>builder.Services.AddCors(options =>

{{

    options.AddPolicy("AllowFrontend",    options.AddPolicy("AllowFrontend",

        policy =>        policy =>

        {        {

            policy.WithOrigins("http://localhost:3000", "http://localhost:5173")            policy.WithOrigins("http://localhost:3000", "http://localhost:5173")

                  .AllowAnyHeader()                  .AllowAnyHeader()

                  .AllowAnyMethod();                  .AllowAnyMethod();

        });        });

});});



builder.Services.AddSingleton<TaskStorage>();builder.Services.AddSingleton<TaskStorage>();



var app = builder.Build();var app = builder.Build();



if (app.Environment.IsDevelopment())if (app.Environment.IsDevelopment())

{{

    app.UseSwagger();    app.UseSwagger();

    app.UseSwaggerUI();    app.UseSwaggerUI();

}}



app.UseCors("AllowFrontend");app.UseCors("AllowFrontend");

app.UseAuthorization();app.UseAuthorization();

app.MapControllers();app.MapControllers();



app.Run();app.Run();



public class TaskStoragepublic class TaskStorage

{{

    private readonly List<TaskItem> _items = new();    private readonly List<TaskItem> _items = new();

    private int _nextId = 1;    private int _nextId = 1;



    public List<TaskItem> GetAll() => _items;    public List<TaskItem> GetAll() => _items;



    public TaskItem? GetById(int id) => _items.FirstOrDefault(t => t.Id == id);    public TaskItem? GetById(int id) => _items.FirstOrDefault(t => t.Id == id);



    public TaskItem Add(string desc)    public TaskItem Add(string desc)

    {    {

        var task = new TaskItem        var task = new TaskItem

        {        {

            Id = _nextId++,            Id = _nextId++,

            Description = desc,            Description = desc,

            IsCompleted = false            IsCompleted = false

        };        };

        _items.Add(task);        _items.Add(task);

        return task;        return task;

    }    }



    public bool Update(int id, string desc, bool done)    public bool Update(int id, string desc, bool done)

    {    {

        var task = GetById(id);        var task = GetById(id);

        if (task == null) return false;        if (task == null) return false;



        task.Description = desc;        task.Description = desc;

        task.IsCompleted = done;        task.IsCompleted = done;

        return true;        return true;

    }    }



    public bool Delete(int id)    public bool Delete(int id)

    {    {

        var task = GetById(id);        var task = GetById(id);

        if (task == null) return false;        if (task == null) return false;



        _items.Remove(task);        _items.Remove(task);

        return true;        return true;

    }    }

}}

