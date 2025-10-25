using Microsoft.AspNetCore.Builder;using Microsoft.AspNetCore.Builder;using Microsoft.AspNetCore.Builder;

using Microsoft.Extensions.DependencyInjection;

using Microsoft.Extensions.Hosting;using Microsoft.Extensions.DependencyInjection;using Microsoft.Extensions.DependencyInjection;

using System;

using System.Collections.Generic;using Microsoft.Extensions.Hosting;using Microsoft.Extensions.Hosting;

using System.Linq;

using TaskManagerAPI.Models;using System;using System;



var builder = WebApplication.CreateBuilder(args);using System.Collections.Generic;using System.Collections.Generic;



builder.Services.AddControllers();using System.Linq;using System.Linq;

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();using TaskManagerAPI.Models;using TaskManagerAPI.Models;



builder.Services.AddCors(options =>

{

    options.AddPolicy("AllowFrontend",var builder = WebApplication.CreateBuilder(args);var builder = WebApplication.CreateBuilder(args);

        policy =>

        {

            policy.WithOrigins(

                "http://localhost:3000", builder.Services.AddControllers();builder.Services.AddControllers();

                "http://localhost:5173",

                "https://harsha-050.github.io")builder.Services.AddEndpointsApiExplorer();builder.Services.AddEndpointsApiExplorer();

                  .AllowAnyHeader()

                  .AllowAnyMethod();builder.Services.AddSwaggerGen();builder.Services.AddSwaggerGen();

        });

});



builder.Services.AddSingleton<TaskStorage>();builder.Services.AddCors(options =>builder.Services.AddCors(options =>



var app = builder.Build();{{



if (app.Environment.IsDevelopment())    options.AddPolicy("AllowFrontend",    options.AddPolicy("AllowFrontend",

{

    app.UseSwagger();        policy =>        policy =>

    app.UseSwaggerUI();

}        {        {



app.UseCors("AllowFrontend");            policy.WithOrigins("http://localhost:3000", "http://localhost:5173")            policy.WithOrigins("http://localhost:3000", "http://localhost:5173")

app.UseAuthorization();

app.MapControllers();                  .AllowAnyHeader()                  .AllowAnyHeader()



app.Run();                  .AllowAnyMethod();                  .AllowAnyMethod();



public class TaskStorage        });        });

{

    private readonly List<TaskItem> _items = new();});});

    private int _nextId = 1;



    public List<TaskItem> GetAll() => _items;

builder.Services.AddSingleton<TaskStorage>();builder.Services.AddSingleton<TaskStorage>();

    public TaskItem? GetById(int id) => _items.FirstOrDefault(t => t.Id == id);



    public TaskItem Add(string desc)

    {var app = builder.Build();var app = builder.Build();

        var task = new TaskItem

        {

            Id = _nextId++,

            Description = desc,if (app.Environment.IsDevelopment())if (app.Environment.IsDevelopment())

            IsCompleted = false

        };{{

        _items.Add(task);

        return task;    app.UseSwagger();    app.UseSwagger();

    }

    app.UseSwaggerUI();    app.UseSwaggerUI();

    public bool Update(int id, string desc, bool done)

    {}}

        var task = GetById(id);

        if (task == null) return false;



        task.Description = desc;app.UseCors("AllowFrontend");app.UseCors("AllowFrontend");

        task.IsCompleted = done;

        return true;app.UseAuthorization();app.UseAuthorization();

    }

app.MapControllers();app.MapControllers();

    public bool Delete(int id)

    {

        var task = GetById(id);

        if (task == null) return false;app.Run();app.Run();



        _items.Remove(task);

        return true;

    }public class TaskStoragepublic class TaskStorage

}

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

