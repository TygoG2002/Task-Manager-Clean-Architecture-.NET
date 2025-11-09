using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Application.Common.Interfaces;

namespace CleanArchitecture.Application.Features
{

    public class UpdateTaskCommand
    {
        public int Id { get; set; }
        public bool IsCompleted { get; set; }
    }

    public class UpdateTaskHandler
    {
        private readonly ITaskRepository ITaskRepository;
        public UpdateTaskHandler(ITaskRepository ITaskRepository)
        {
            this.ITaskRepository = ITaskRepository;
        }

        public async Task Execute(UpdateTaskCommand command)
        {
            var currentTaskItem = await ITaskRepository.GetByIdAsync(command.Id);

            if (currentTaskItem != null)
            {
                currentTaskItem.IsCompleted = command.IsCompleted;
                await ITaskRepository.UpdateAsync(currentTaskItem);
            }
        }
    }
    }
