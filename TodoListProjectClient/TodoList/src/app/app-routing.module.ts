import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TaskListComponent } from './task-list/task-list.component';
import { AddNewTaskComponent } from './add-new-task/add-new-task.component';
import { EditTaskComponent } from './edit-task/edit-task.component';
import { TableTasksComponent } from './table-tasks/table-tasks.component';

const routes: Routes = [
  { path: '', component: TaskListComponent },
  { path: 'tasks', component: TaskListComponent },
  // { path: 'edit-task', component: EditTaskComponent },
  { path: 'add-task', component: AddNewTaskComponent },
  { path: 'tableTasks', component: TableTasksComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
