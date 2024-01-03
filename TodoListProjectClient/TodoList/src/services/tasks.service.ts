import { HttpBackend, HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../app/enviroments/environments';
import { TaskModel } from '../models/TaskModel';

@Injectable({
  providedIn: 'root',
})
export class TasksService {
  private url = environment.baseUrl + 'tasks';

  constructor(private http: HttpClient) {}

  public getAllTasks(): Observable<TaskModel[]> {
    return this.http.get<TaskModel[]>(this.url);
  }

  public getTaskById(id: number): Observable<TaskModel> {
    return this.http.get<TaskModel>(this.url + '/' + id);
  }

  public addTask(task: TaskModel): Observable<TaskModel> {
    return this.http.post<TaskModel>(this.url, task);
  }

  public updateTask(task: TaskModel): Observable<boolean> {
    return this.http.put<boolean>(this.url + '/' + task.id, task);
  }

  public deleteTask(id: number): Observable<boolean> {
    return this.http.delete<boolean>(this.url + '/' + id);
  }
}
