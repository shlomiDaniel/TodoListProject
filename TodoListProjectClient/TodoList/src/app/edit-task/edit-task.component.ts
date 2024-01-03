import { Component, Inject, OnInit, inject } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { TasksService } from '../../services/tasks.service';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'edit-task',
  templateUrl: './edit-task.component.html',
  styleUrl: './edit-task.component.css',
})
export class EditTaskComponent implements OnInit {
  editForm: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private taskService: TasksService,
    private dialog: MatDialogRef<EditTaskComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {
    this.editForm = this.formBuilder.group({
      id: [''],
      title: [''],
      description: [''],
      isCompleted: [false],
      targetDate: Date.now(),
      userId: 0,
      user: {},
    });
  }

  ngOnInit(): void {
    this.editForm.patchValue(this.data);
  }

  onFormSubmit() {
    if (this.editForm.valid) {
      if (!this.data) {
        this.taskService.addTask(this.editForm.value).subscribe({
          next: (data) => {
            alert('Task added successfully');
            this.dialog.close(true);
          },
          error: (error) => {
            console.error('There was an error!', error);
          },
        });
      } else {
        this.taskService.updateTask(this.editForm.value).subscribe({
          next: (data) => {
            alert('Task edited successfully');
            this.dialog.close(true);
          },
          error: (error) => {
            console.error('There was an error!', error);
          },
        });
      }
    }
  }

  close() {
    this.dialog.close();
  }
}
