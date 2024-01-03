import { Component, OnInit } from '@angular/core';
import { TasksService } from '../../services/tasks.service';
import { TaskModel } from './../../models/TaskModel';
@Component({
  selector: 'app-task-list',
  templateUrl: './task-list.component.html',
  styleUrl: './task-list.component.css',
})
export class TaskListComponent implements OnInit {
  tasks: TaskModel[] = [];

  constructor(private taskService: TasksService) {}

  ngOnInit() {
    this.taskService.getAllTasks().subscribe((tasks: TaskModel[]) => {
      this.tasks = tasks;
    });
  }
}
