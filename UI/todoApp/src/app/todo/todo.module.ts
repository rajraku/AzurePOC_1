import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { TodoRoutingModule } from './todo-routing.module';
import { TodoListComponent } from './todo-list/todo-list.component';

@NgModule({
  declarations: [TodoListComponent],
  imports: [
    CommonModule,
    FormsModule,
    TodoRoutingModule
  ]
})
export class TodoModule { }
