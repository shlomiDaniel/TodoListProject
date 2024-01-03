import { UserModel } from './UserModel';

export interface TaskModel {
  id?: number;
  title?: string;
  description: string;
  isCompleted: boolean;
  TargetDate: Date;
  UserId?: number;
  User?: UserModel;
}
