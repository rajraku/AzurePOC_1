import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-todo-list',
  templateUrl: './todo-list.component.html',
  styleUrls: ['./todo-list.component.css']
})
export class TodoListComponent implements OnInit {

  constructor() { }

  list = [{
    task: 'first',
    isCompleted: false
  },
{
  task: 'second',
  isCompleted: true
}]
  ngOnInit() {
  }

}
