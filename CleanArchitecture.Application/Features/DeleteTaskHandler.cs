using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Interfaces;

namespace CleanArchitecture.Application.Features
{
    public class DeleteTaskCommand
    {   
        public int Id { get; set; }
    }
    public class DeleteTaskHandler
    {
        private readonly ITaskRepository taskRepository;

        public DeleteTaskHandler(ITaskRepository taskRepository)
        {
            this.taskRepository = taskRepository;
        }

        public async Task Execute (DeleteTaskCommand command)
        {
            var currentTaskItem = await taskRepository.GetByIdAsync(command.Id);
            if (currentTaskItem != null)
            {
                await taskRepository.DeleteAsync(currentTaskItem);
            }
        }
    }
}
