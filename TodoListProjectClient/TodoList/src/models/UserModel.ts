import { TaskModel } from "./TaskModel";

export interface UserModel {
  id?: number;
  firstName: string;
  lastName: string;
  Task?: TaskModel[] ;
}
