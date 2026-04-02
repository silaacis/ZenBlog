import { Component, OnInit, signal } from '@angular/core';
import { blogDto } from './_models/blog';
declare const alertify: any;

@Component({
  selector: 'app-root',
  templateUrl: './app.html',
  standalone: false,
  styleUrl: './app.css'
})
export class App implements OnInit{
  protected readonly title = signal('ZenBlogClient');

  ngOnInit(): void {
    alertify.set('notifier','position','top-right')
  }

}
