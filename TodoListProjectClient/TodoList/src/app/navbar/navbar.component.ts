import { Component } from '@angular/core';
import { TasksService } from '../../services/tasks.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css',
})
export class NavbarComponent {
  constructor(public service: TasksService) {}
  ngOnInit(): void {
    this.service.getAllTasks().subscribe((data) => {
      console.log(data);
    });
  }
}
