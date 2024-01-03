import { Component, Input } from '@angular/core';
import { TaskModel } from '../../models/TaskModel';

@Component({
  selector: 'app-task-card',
  templateUrl: './task-card.component.html',
  styleUrl: './task-card.component.css',
})
export class TaskCardComponent {
  @Input() TaskModel!: TaskModel;
}
