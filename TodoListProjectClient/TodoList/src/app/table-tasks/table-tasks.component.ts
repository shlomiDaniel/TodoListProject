import { Component, OnInit } from '@angular/core';
import { EditTaskComponent } from '../edit-task/edit-task.component';
import { MatDialog } from '@angular/material/dialog';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { TaskModel } from '../../models/TaskModel';
import { TasksService } from '../../services/tasks.service';

@Component({
  selector: 'app-table-tasks',
  templateUrl: './table-tasks.component.html',
  styleUrl: './table-tasks.component.css',
})
export class TableTasksComponent implements OnInit {
  displayedColumns: string[] = [
    'id',
    'title',
    'description',
    'isCompleted',
    'targetDate',
    'userId',
    'action',
  ];

  dataSource: MatTableDataSource<TaskModel> =
    new MatTableDataSource<TaskModel>();

  constructor(public dialog: MatDialog, public service: TasksService) {}
  ngOnInit(): void {
    this.service.getAllTasks().subscribe({
      next: (data) => {
        this.dataSource = new MatTableDataSource(data);
      },
      error: (error) => {
        console.error('There was an error!', error);
      },
    });
  }

  getallTasks() {
    this.service.getAllTasks().subscribe({
      next: (data) => {
        this.dataSource = new MatTableDataSource(data);
      },
      error: (error) => {
        console.error('There was an error!', error);
      },
    });
  }

  OpenEditTaskForm(data: TaskModel) {
    const DialogRef = this.dialog.open(EditTaskComponent, {
      data: data,
    });
    DialogRef.afterClosed().subscribe({
      next: (value) => {
        if (value) {
          this.getallTasks();
        }
      },
    });
  }

  deleteTask(id: number) {
    this.service.deleteTask(id).subscribe({
      next: () => {
        alert('Task deleted successfully');
        this.getallTasks();
      },
      error: (error) => {
        alert('There was an error!');
        console.error('There was an error!', error);
      },
    });
  }
}
