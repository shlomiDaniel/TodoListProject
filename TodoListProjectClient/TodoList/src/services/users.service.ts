import { Injectable } from '@angular/core';
import { environment } from '../app/enviroments/environments';
import { HttpClient } from '@angular/common/http';
import { UserModel } from '../models/UserModel';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class UsersService {
  private url = environment.baseUrl + 'users';

  constructor(private http: HttpClient) {}

  public getAllUsers(): Observable<UserModel> {
    return this.http.get<UserModel>(this.url);
  }

  public getUserById(id: number): Observable<UserModel> {
    return this.http.get<UserModel>(this.url + '/' + id);
  }

  public addUser(user: UserModel): Observable<UserModel> {
    return this.http.post<UserModel>(this.url, user);
  }

  public updateUser(user: any): Observable<UserModel> {
    return this.http.put<UserModel>(this.url + '/' + user.id, user);
  }

  public deleteUser(id: number): Observable<UserModel> {
    return this.http.delete<UserModel>(this.url + '/' + id);
  }
}
