import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { TasksService } from '../../services/tasks.service';
import { UserModel } from '../../models/UserModel';
import { TaskModel } from '../../models/TaskModel';
import { EditTaskComponent } from '../edit-task/edit-task.component';
import { MatDialog } from '@angular/material/dialog';

import { Router } from '@angular/router';
@Component({
  selector: 'app-add-new-task',
  templateUrl: './add-new-task.component.html',
  styleUrl: './add-new-task.component.css',
})
export class AddNewTaskComponent implements OnInit {
  taskForm!: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private taskService: TasksService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.taskForm = this.formBuilder.group({
      title: ['', [Validators.required]],
      description: [''],
      isCompleted: [false],
      targetDate: new Date(),
      userId: 0,
      user: {},
    });
  }

  onSubmit() {
    if (this.taskForm.valid) {
      const newTask = this.taskForm.value as TaskModel;
      this.taskService.addTask(newTask).subscribe(
        (response) => {
          alert('Task added successfully');
          console.log('Task added successfully:', response);
          this.router.navigate(['/']);
        },
        (error) => {
          alert('Error adding task');
          console.error('Error adding task:', error);
        }
      );
    }
  }

  get title() {
    return this.taskForm.get('title');
  }
  get description() {
    return this.taskForm.get('title');
  }
}
